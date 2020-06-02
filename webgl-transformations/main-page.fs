namespace Laye.WebGl

open Fable.Core
open Fable.Core.JsInterop
open Laye.Fable.Bindings.WebGl

module Page =
  let vshaderSource = """
  attribute vec4 aPoints;
  uniform mat4 rMat;
  void main() {
    gl_Position = rMat * aPoints;
    gl_PointSize = 10.0;
  }
  """
  let fshaderSource = """
  precision mediump float;
  void main() {
    gl_FragColor = vec4(1.0, 0.0, 0.0, 1.0);
  }
  """

  let vertices =
    [| 0.0; 0.5; -0.5; -0.5; 0.5; -0.5 |]
    |> Array.map float32

  let doc = Browser.Dom.document
  let canvas = doc.createElement ("canvas")
  canvas.id <- "main-canvas"
  canvas.setAttribute("width", "400")
  canvas.setAttribute("height", "400")
  doc.body.appendChild(canvas) |> ignore

  let createShader (gl: WebGLRenderingContext) shaderType source = 
    let shader = gl.createShader(shaderType)
    gl.shaderSource(shader, source)
    gl.compileShader(shader)
    let success: bool = gl.getShaderParameter(shader, gl.COMPILE_STATUS) |> unbox
    if not success then 
      gl.getShaderInfoLog(shader)
      |> printfn "%s"
      failwith "Failed to create shader"
    else
      shader

  let createProgram (gl: WebGLRenderingContext) vShader fShader =
    let program = gl.createProgram()
    gl.attachShader(program, vShader)
    gl.attachShader(program, fShader)
    gl.linkProgram(program)
    let success: bool = gl.getProgramParameter(program, gl.LINK_STATUS) |> unbox
    if not success then 
      gl.getProgramInfoLog(program)
      |> printfn "%s"
      failwith "Failed to create shader"
    else
      program

  let initVertexBuffer (gl: WebGLRenderingContext) attr =
    let buffer = gl.createBuffer()
    if isNull buffer then failwith "Failed to create buffer"
    gl.bindBuffer(gl.ARRAY_BUFFER, buffer)
    gl.bufferData(gl.ARRAY_BUFFER, !^ vertices.buffer, gl.STATIC_DRAW)
    gl.vertexAttribPointer(attr, 2.0, gl.FLOAT, false, 0.0, 0.0)
    gl.enableVertexAttribArray(attr)

  doc.body.onload <- 
    fun _ ->
      let mutable m = Laye.Fable.Graphics.Mat4.create()
      let v = Laye.Fable.Graphics.Vec3.fromValues(1.0, 0.0, 0.0)
      let r = Laye.Fable.Graphics.GlMatrix.toRadian(75.0)
      Laye.Fable.Graphics.Mat4.fromRotation(&m, r, v)
      |> printfn "%A"
      
      let canvas: Browser.Types.HTMLCanvasElement = doc.getElementById("main-canvas") |> unbox
      let glCtx: WebGLRenderingContext = canvas.getContext("webgl") |> unbox
      let vs = createShader glCtx glCtx.VERTEX_SHADER vshaderSource
      let fs = createShader glCtx glCtx.FRAGMENT_SHADER fshaderSource
      let program = createProgram glCtx vs fs
      glCtx.useProgram(program)
      let rMat = glCtx.getUniformLocation(program, "rMat")
      glCtx.uniformMatrix4fv(rMat, false, !! m)
      let aPoints = glCtx.getAttribLocation(program, "aPoints")
      initVertexBuffer glCtx aPoints
      glCtx.clearColor(0.0, 0.0, 0.0, 1.0)
      glCtx.clear(glCtx.COLOR_BUFFER_BIT)
      glCtx.drawArrays(glCtx.TRIANGLES, 0, 3L)
