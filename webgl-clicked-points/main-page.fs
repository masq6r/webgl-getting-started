namespace Laye.WebGl

open Fable.Core
open Laye.Fable.Bindings.WebGl

module Page =
  let vshaderSource = """
  attribute vec4 aPoints;
  void main() {
    gl_Position = aPoints;
    gl_PointSize = 10.0;
  }
  """
  let fshaderSource = """
  precision mediump float;
  void main() {
    gl_FragColor = vec4(1.0, 0.0, 0.0, 1.0);
  }
  """

  let createShader (gl: WebGLRenderingContext) shaderType source = 
    let shader = gl.createShader(shaderType)
    gl.shaderSource(shader, source)
    gl.compileShader(shader)
    let success: bool = gl.getShaderParameter(shader, gl.COMPILE_STATUS) |> unbox
    if not success then failwith "Failed to create shader"
    else shader

  let createProgram (gl: WebGLRenderingContext) vShader fShader =
    let program = gl.createProgram()
    gl.attachShader(program, vShader)
    gl.attachShader(program, fShader)
    gl.linkProgram(program)
    let success: bool = gl.getProgramParameter(program, gl.LINK_STATUS) |> unbox
    if not success then failwith "Failed to create shader"
    else program

  let doc = Browser.Dom.document
  let clickedPoints = ResizeArray<float * float>()
  let canvas = doc.createElement ("canvas")
  canvas.id <- "main-canvas"
  canvas.setAttribute("width", "400")
  canvas.setAttribute("height", "400")
  doc.body.appendChild(canvas) |> ignore

  doc.body.onload <- 
    fun _ ->
      let canvas: Browser.Types.HTMLCanvasElement = doc.getElementById("main-canvas") |> unbox
      let glCtx: WebGLRenderingContext = canvas.getContext("webgl") |> unbox
      let vs = createShader glCtx glCtx.VERTEX_SHADER vshaderSource
      let fs = createShader glCtx glCtx.FRAGMENT_SHADER fshaderSource
      let program = createProgram glCtx vs fs
      glCtx.useProgram(program)
      let aPoints = glCtx.getAttribLocation(program, "aPoints")
      glCtx.clearColor(0.0, 0.0, 0.0, 1.0)
      glCtx.clear(glCtx.COLOR_BUFFER_BIT)

      canvas.onmousedown <-
        fun evt ->
          let tgt: Browser.Types.HTMLCanvasElement = unbox evt.target
          let rect = tgt.getBoundingClientRect()
          let x = ((evt.clientX - rect.left) - canvas.width / 2.0) / (canvas.width / 2.0)
          let y = (canvas.height / 2.0 - (evt.clientY - rect.top)) / (canvas.height / 2.0)
          clickedPoints.Add(x, y)
          glCtx.clear(glCtx.COLOR_BUFFER_BIT)
          for px, py in clickedPoints do 
            glCtx.vertexAttrib3f(aPoints, px, py, 0.0)
            glCtx.drawArrays(glCtx.POINTS, 0, 1L) 

