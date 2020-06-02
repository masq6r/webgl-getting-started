namespace Laye.Fable.Graphics

open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop

[<Import("glMatrix", "gl-matrix")>]
[<AbstractClass>]
type GlMatrix =
  static member EPSILON: float = jsNative
  static member toRadian(degree: float): float = jsNative

[<Import("vec2", "gl-matrix")>]
[<AbstractClass>]
type Vec2 private () =
  static member create(): Vec2 = jsNative
  static member len(a: Vec2): float = jsNative
  static member fromValues(x: float, y: float) : Vec2 = jsNative

[<Import("vec3", "gl-matrix")>]
[<AbstractClass>]
type Vec3 private () =
  static member create(): Vec3 = jsNative
  static member len(a: Vec3): float = jsNative
  static member fromValues(x: float, y: float, z: float) : Vec3 = jsNative


[<Import("mat2", "gl-matrix")>]
[<AbstractClass>]
type Mat2 private () =
  static member create(): Mat2 = jsNative
  static member fromValues(m00: float, m01: float, m10: float, m11: float): Mat2 = jsNative
  static member fromRotation(out: outref<Mat2>, rad: float): Mat2 = jsNative
  // member me.ToArray() =
  //   ()

[<Import("mat4", "gl-matrix")>]
[<AbstractClass>]
type Mat4 private () =
  static member create(): Mat4 = jsNative
  static member fromRotation(out: outref<Mat4>, rad: float, axis: Vec3): Mat4 = jsNative


//       abstract create: unit -> mat2
//       /// <summary>Creates a new mat2 initialized with values from an existing matrix</summary>
//       /// <param name="a">matrix to clone</param>
//       abstract clone: a: mat2 -> mat2
//       /// <summary>Copy the values from one mat2 to another</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the source matrix</param>
//       abstract copy: out: mat2 * a: mat2 -> mat2
//       /// <summary>Set a mat2 to the identity matrix</summary>
//       /// <param name="out">the receiving matrix</param>
//       abstract identity: out: mat2 -> mat2
//       /// <summary>Create a new mat2 with the given values</summary>
//       /// <param name="m00">Component in column 0, row 0 position (index 0)</param>
//       /// <param name="m01">Component in column 0, row 1 position (index 1)</param>
//       /// <param name="m10">Component in column 1, row 0 position (index 2)</param>
//       /// <param name="m11">Component in column 1, row 1 position (index 3)</param>
//       abstract fromValues: m00: float * m01: float * m10: float * m11: float -> mat2

module Matrix =

  type IGlMatrix =
    abstract EPSILON: float with get, set
    abstract ARRAY_TYPE: obj option with get, set
    abstract RANDOM: unit -> float
    abstract ENABLE_SIMD: bool with get, set
    abstract SIMD_AVAILABLE: bool with get, set
    abstract USE_SIMD: bool with get, set
    /// <summary>Sets the type of array used when creating new vectors and matrices</summary>
    /// <param name="type">- Array type, such as Float32Array or Array</param>
    abstract setMatrixArrayType: ``type``: obj option -> unit
    /// <summary>Convert Degree To Radian</summary>
    /// <param name="a">- Angle in Degrees</param>
    abstract toRadian: a: float -> float
    /// <summary>Tests whether or not the arguments have approximately the same value, within an absolute
    /// or relative tolerance of glMatrix.EPSILON (an absolute tolerance is used for values less
    /// than or equal to 1.0, and a relative tolerance is used for larger values)</summary>
    /// <param name="a">- The first number to test.</param>
    /// <param name="b">- The second number to test.</param>
    abstract equals: a: float * b: float -> bool
  
  let glMatrix: IGlMatrix = importMember "gl-matrix"

  type IVec2 =
    // inherit Float32Array
    /// Creates a new, empty vec2
    abstract create: unit -> IVec2
    /// <summary>Creates a new vec2 initialized with values from an existing vector</summary>
    /// <param name="a">a vector to clone</param>
    abstract clone: a: IVec2 -> IVec2
    /// <summary>Creates a new vec2 initialized with the given values</summary>
    /// <param name="x">X component</param>
    /// <param name="y">Y component</param>
    abstract fromValues: x: float * y: float -> IVec2
    /// <summary>Copy the values from one vec2 to another</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">the source vector</param>
    abstract copy: out: outref<IVec2> * a: IVec2 -> IVec2
    /// <summary>Set the components of a vec2 to the given values</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="x">X component</param>
    /// <param name="y">Y component</param>
    abstract setValues: out: IVec2 * x: float * y: float -> IVec2
    /// <summary>Adds two vec2's</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">the first operand</param>
    /// <param name="b">the second operand</param>
    abstract add: out: IVec2 * a: IVec2 * b: IVec2 -> IVec2
    /// <summary>Subtracts vector b from vector a</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">the first operand</param>
    /// <param name="b">the second operand</param>
    abstract subtract: out: IVec2 * a: IVec2 * b: IVec2 -> IVec2
    /// <summary>Subtracts vector b from vector a</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">the first operand</param>
    /// <param name="b">the second operand</param>
    abstract sub: out: IVec2 * a: IVec2 * b: IVec2 -> IVec2
    /// <summary>Multiplies two vec2's</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">the first operand</param>
    /// <param name="b">the second operand</param>
    abstract multiply: out: IVec2 * a: IVec2 * b: IVec2 -> IVec2
    /// <summary>Multiplies two vec2's</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">the first operand</param>
    /// <param name="b">the second operand</param>
    abstract mul: out: IVec2 * a: IVec2 * b: IVec2 -> IVec2
    /// <summary>Divides two vec2's</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">the first operand</param>
    /// <param name="b">the second operand</param>
    abstract divide: out: IVec2 * a: IVec2 * b: IVec2 -> IVec2
    /// <summary>Divides two vec2's</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">the first operand</param>
    /// <param name="b">the second operand</param>
    abstract div: out: IVec2 * a: IVec2 * b: IVec2 -> IVec2
    /// <summary>Math.ceil the components of a vec2</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">vector to ceil</param>
    abstract ceil: out: IVec2 * a: IVec2 -> IVec2
    /// <summary>Math.floor the components of a vec2</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">vector to floor</param>
    abstract floor: out: IVec2 * a: IVec2 -> IVec2
    /// <summary>Returns the minimum of two vec2's</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">the first operand</param>
    /// <param name="b">the second operand</param>
    abstract min: out: IVec2 * a: IVec2 * b: IVec2 -> IVec2
    /// <summary>Returns the maximum of two vec2's</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">the first operand</param>
    /// <param name="b">the second operand</param>
    abstract max: out: IVec2 * a: IVec2 * b: IVec2 -> IVec2
    /// <summary>Math.round the components of a vec2</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">vector to round</param>
    abstract round: out: IVec2 * a: IVec2 -> IVec2
    /// <summary>Scales a vec2 by a scalar number</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">the vector to scale</param>
    /// <param name="b">amount to scale the vector by</param>
    abstract scale: out: IVec2 * a: IVec2 * b: float -> IVec2
    /// <summary>Adds two vec2's after scaling the second operand by a scalar value</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">the first operand</param>
    /// <param name="b">the second operand</param>
    /// <param name="scale">the amount to scale b by before adding</param>
    abstract scaleAndAdd: out: IVec2 * a: IVec2 * b: IVec2 * scale: float -> IVec2
    /// <summary>Calculates the euclidian distance between two vec2's</summary>
    /// <param name="a">the first operand</param>
    /// <param name="b">the second operand</param>
    abstract distance: a: IVec2 * b: IVec2 -> float
    /// <summary>Calculates the euclidian distance between two vec2's</summary>
    /// <param name="a">the first operand</param>
    /// <param name="b">the second operand</param>
    abstract dist: a: IVec2 * b: IVec2 -> float
    /// <summary>Calculates the squared euclidian distance between two vec2's</summary>
    /// <param name="a">the first operand</param>
    /// <param name="b">the second operand</param>
    abstract squaredDistance: a: IVec2 * b: IVec2 -> float
    /// <summary>Calculates the squared euclidian distance between two vec2's</summary>
    /// <param name="a">the first operand</param>
    /// <param name="b">the second operand</param>
    abstract sqrDist: a: IVec2 * b: IVec2 -> float
    /// <summary>Calculates the length of a vec2</summary>
    /// <param name="a">vector to calculate length of</param>
    abstract length: a: IVec2 -> float
    /// <summary>Calculates the length of a vec2</summary>
    /// <param name="a">vector to calculate length of</param>
    abstract len: a: IVec2 -> float
    /// <summary>Calculates the squared length of a vec2</summary>
    /// <param name="a">vector to calculate squared length of</param>
    abstract squaredLength: a: IVec2 -> float
    /// <summary>Calculates the squared length of a vec2</summary>
    /// <param name="a">vector to calculate squared length of</param>
    abstract sqrLen: a: IVec2 -> float
    /// <summary>Negates the components of a vec2</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">vector to negate</param>
    abstract negate: out: IVec2 * a: IVec2 -> IVec2
    /// <summary>Returns the inverse of the components of a vec2</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">vector to invert</param>
    abstract inverse: out: IVec2 * a: IVec2 -> IVec2
    /// <summary>Normalize a vec2</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">vector to normalize</param>
    abstract normalize: out: IVec2 * a: IVec2 -> IVec2
    /// <summary>Calculates the dot product of two vec2's</summary>
    /// <param name="a">the first operand</param>
    /// <param name="b">the second operand</param>
    abstract dot: a: IVec2 * b: IVec2 -> float
    /// <summary>Computes the cross product of two vec2's
    /// Note that the cross product must by definition produce a 3D vector</summary>
    /// <param name="out">the receiving vector</param>
    /// <param name="a">the first operand</param>
    /// <param name="b">the second operand</param>
    // abstract cross: out: vec3 * a: IVec2 * b: IVec2 -> vec3
    // /// <summary>Performs a linear interpolation between two vec2's</summary>
    // /// <param name="out">the receiving vector</param>
    // /// <param name="a">the first operand</param>
    // /// <param name="b">the second operand</param>
    // /// <param name="t">interpolation amount between the two inputs</param>
    // abstract lerp: out: IVec2 * a: IVec2 * b: IVec2 * t: float -> IVec2
    // /// <summary>Generates a random unit vector</summary>
    // /// <param name="out">the receiving vector</param>
    // abstract random: out: IVec2 -> IVec2
    // /// <summary>Generates a random vector with the given scale</summary>
    // /// <param name="out">the receiving vector</param>
    // /// <param name="scale">Length of the resulting vector. If ommitted, a unit vector will be returned</param>
    // abstract random: out: IVec2 * scale: float -> IVec2
    // /// <summary>Rotate a 2D vector</summary>
    // /// <param name="out">The receiving vec2</param>
    // /// <param name="a">The vec2 point to rotate</param>
    // /// <param name="b">The origin of the rotation</param>
    // /// <param name="c">The angle of rotation</param>
    // abstract rotate: out: IVec2 * a: IVec2 * b: IVec2 * c: float -> IVec2
    // /// <summary>Transforms the vec2 with a mat2</summary>
    // /// <param name="out">the receiving vector</param>
    // /// <param name="a">the vector to transform</param>
    // /// <param name="m">matrix to transform with</param>
    // abstract transformMat2: out: IVec2 * a: IVec2 * m: mat2 -> IVec2
    // /// <summary>Transforms the vec2 with a mat2d</summary>
    // /// <param name="out">the receiving vector</param>
    // /// <param name="a">the vector to transform</param>
    // /// <param name="m">matrix to transform with</param>
    // abstract transformMat2d: out: IVec2 * a: IVec2 * m: mat2d -> IVec2
    // /// <summary>Transforms the vec2 with a mat3
    // /// 3rd vector component is implicitly '1'</summary>
    // /// <param name="out">the receiving vector</param>
    // /// <param name="a">the vector to transform</param>
    // /// <param name="m">matrix to transform with</param>
    // abstract transformMat3: out: IVec2 * a: IVec2 * m: mat3 -> IVec2
    // /// <summary>Transforms the vec2 with a mat4
    // /// 3rd vector component is implicitly '0'
    // /// 4th vector component is implicitly '1'</summary>
    // /// <param name="out">the receiving vector</param>
    // /// <param name="a">the vector to transform</param>
    // /// <param name="m">matrix to transform with</param>
    // abstract transformMat4: out: IVec2 * a: IVec2 * m: mat4 -> IVec2
    // /// <summary>Perform some operation over an array of vec2s.</summary>
    // /// <param name="a">the array of vectors to iterate over</param>
    // /// <param name="stride">Number of elements between the start of each vec2. If 0 assumes tightly packed</param>
    // /// <param name="offset">Number of elements to skip at the beginning of the array</param>
    // /// <param name="count">Number of vec2s to iterate over. If 0 iterates over entire array</param>
    // /// <param name="fn">Function to call for each vector in the array</param>
    // /// <param name="arg">additional argument to pass to fn</param>
    // abstract forEach: a: Float32Array * stride: float * offset: float * count: float * fn: (IVec2 -> IVec2 -> obj option -> unit) * arg: obj option -> Float32Array
    // /// <summary>Get the angle between two 2D vectors</summary>
    // /// <param name="a">The first operand</param>
    // /// <param name="b">The second operand</param>
    // abstract angle: a: IVec2 * b: IVec2 -> float
    // /// <summary>Perform some operation over an array of vec2s.</summary>
    // /// <param name="a">the array of vectors to iterate over</param>
    // /// <param name="stride">Number of elements between the start of each vec2. If 0 assumes tightly packed</param>
    // /// <param name="offset">Number of elements to skip at the beginning of the array</param>
    // /// <param name="count">Number of vec2s to iterate over. If 0 iterates over entire array</param>
    // /// <param name="fn">Function to call for each vector in the array</param>
    // abstract forEach: a: Float32Array * stride: float * offset: float * count: float * fn: (IVec2 -> IVec2 -> unit) -> Float32Array
    // /// <summary>Returns a string representation of a vector</summary>
    // /// <param name="a">vector to represent as a string</param>
    // abstract str: a: IVec2 -> string
    // /// <summary>Returns whether or not the vectors exactly have the same elements in the same position (when compared with ===)</summary>
    // /// <param name="a">The first vector.</param>
    // /// <param name="b">The second vector.</param>
    // abstract exactEquals: a: IVec2 * b: IVec2 -> bool
    // /// <summary>Returns whether or not the vectors have approximately the same elements in the same position.</summary>
    // /// <param name="a">The first vector.</param>
    // /// <param name="b">The second vector.</param>
    abstract equals: a: IVec2 * b: IVec2 -> bool

  // [<Import("vec2", "gl-matrix")>]
  let vec2: IVec2 = importMember "gl-matrix"

//   type vec3 =
//       inherit Float32Array

//   type [<AllowNullLiteral>] vec3Static =
//       [<Emit "new $0($1...)">] abstract Create: unit -> vec3
//       /// Creates a new, empty vec3
//       abstract create: unit -> vec3
//       /// <summary>Creates a new vec3 initialized with values from an existing vector</summary>
//       /// <param name="a">vector to clone</param>
//       abstract clone: a: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Creates a new vec3 initialized with the given values</summary>
//       /// <param name="x">X component</param>
//       /// <param name="y">Y component</param>
//       /// <param name="z">Z component</param>
//       abstract fromValues: x: float * y: float * z: float -> vec3
//       /// <summary>Copy the values from one vec3 to another</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the source vector</param>
//       abstract copy: out: vec3 * a: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Set the components of a vec3 to the given values</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="x">X component</param>
//       /// <param name="y">Y component</param>
//       /// <param name="z">Z component</param>
//       abstract set: out: vec3 * x: float * y: float * z: float -> vec3
//       /// <summary>Adds two vec3's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract add: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Subtracts vector b from vector a</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract subtract: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Subtracts vector b from vector a</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract sub: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Multiplies two vec3's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract multiply: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Multiplies two vec3's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract mul: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Divides two vec3's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract divide: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Divides two vec3's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract div: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Math.ceil the components of a vec3</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">vector to ceil</param>
//       abstract ceil: out: vec3 * a: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Math.floor the components of a vec3</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">vector to floor</param>
//       abstract floor: out: vec3 * a: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Returns the minimum of two vec3's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract min: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Returns the maximum of two vec3's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract max: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Math.round the components of a vec3</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">vector to round</param>
//       abstract round: out: vec3 * a: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Scales a vec3 by a scalar number</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the vector to scale</param>
//       /// <param name="b">amount to scale the vector by</param>
//       abstract scale: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: float -> vec3
//       /// <summary>Adds two vec3's after scaling the second operand by a scalar value</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       /// <param name="scale">the amount to scale b by before adding</param>
//       abstract scaleAndAdd: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> * scale: float -> vec3
//       /// <summary>Calculates the euclidian distance between two vec3's</summary>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract distance: a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> float
//       /// <summary>Calculates the euclidian distance between two vec3's</summary>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract dist: a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> float
//       /// <summary>Calculates the squared euclidian distance between two vec3's</summary>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract squaredDistance: a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> float
//       /// <summary>Calculates the squared euclidian distance between two vec3's</summary>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract sqrDist: a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> float
//       /// <summary>Calculates the length of a vec3</summary>
//       /// <param name="a">vector to calculate length of</param>
//       abstract length: a: U2<vec3, ResizeArray<float>> -> float
//       /// <summary>Calculates the length of a vec3</summary>
//       /// <param name="a">vector to calculate length of</param>
//       abstract len: a: U2<vec3, ResizeArray<float>> -> float
//       /// <summary>Calculates the squared length of a vec3</summary>
//       /// <param name="a">vector to calculate squared length of</param>
//       abstract squaredLength: a: U2<vec3, ResizeArray<float>> -> float
//       /// <summary>Calculates the squared length of a vec3</summary>
//       /// <param name="a">vector to calculate squared length of</param>
//       abstract sqrLen: a: U2<vec3, ResizeArray<float>> -> float
//       /// <summary>Negates the components of a vec3</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">vector to negate</param>
//       abstract negate: out: vec3 * a: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Returns the inverse of the components of a vec3</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">vector to invert</param>
//       abstract inverse: out: vec3 * a: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Normalize a vec3</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">vector to normalize</param>
//       abstract normalize: out: vec3 * a: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Calculates the dot product of two vec3's</summary>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract dot: a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> float
//       /// <summary>Computes the cross product of two vec3's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract cross: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> vec3
//       /// <summary>Performs a linear interpolation between two vec3's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       /// <param name="t">interpolation amount between the two inputs</param>
//       abstract lerp: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> * t: float -> vec3
//       /// <summary>Performs a hermite interpolation with two control points</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       /// <param name="c">the third operand</param>
//       /// <param name="d">the fourth operand</param>
//       /// <param name="t">interpolation amount between the two inputs</param>
//       abstract hermite: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> * c: U2<vec3, ResizeArray<float>> * d: U2<vec3, ResizeArray<float>> * t: float -> vec3
//       /// <summary>Performs a bezier interpolation with two control points</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       /// <param name="c">the third operand</param>
//       /// <param name="d">the fourth operand</param>
//       /// <param name="t">interpolation amount between the two inputs</param>
//       abstract bezier: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> * c: U2<vec3, ResizeArray<float>> * d: U2<vec3, ResizeArray<float>> * t: float -> vec3
//       /// <summary>Generates a random unit vector</summary>
//       /// <param name="out">the receiving vector</param>
//       abstract random: out: vec3 -> vec3
//       /// <summary>Generates a random vector with the given scale</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="scale">Length of the resulting vector. If omitted, a unit vector will be returned</param>
//       abstract random: out: vec3 * scale: float -> vec3
//       /// <summary>Transforms the vec3 with a mat3.</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the vector to transform</param>
//       /// <param name="m">the 3x3 matrix to transform with</param>
//       abstract transformMat3: out: vec3 * a: U2<vec3, ResizeArray<float>> * m: mat3 -> vec3
//       /// <summary>Transforms the vec3 with a mat4.
//       /// 4th vector component is implicitly '1'</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the vector to transform</param>
//       /// <param name="m">matrix to transform with</param>
//       abstract transformMat4: out: vec3 * a: U2<vec3, ResizeArray<float>> * m: mat4 -> vec3
//       /// <summary>Transforms the vec3 with a quat</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the vector to transform</param>
//       /// <param name="q">quaternion to transform with</param>
//       abstract transformQuat: out: vec3 * a: U2<vec3, ResizeArray<float>> * q: quat -> vec3
//       /// <summary>Rotate a 3D vector around the x-axis</summary>
//       /// <param name="out">The receiving vec3</param>
//       /// <param name="a">The vec3 point to rotate</param>
//       /// <param name="b">The origin of the rotation</param>
//       /// <param name="c">The angle of rotation</param>
//       abstract rotateX: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> * c: float -> vec3
//       /// <summary>Rotate a 3D vector around the y-axis</summary>
//       /// <param name="out">The receiving vec3</param>
//       /// <param name="a">The vec3 point to rotate</param>
//       /// <param name="b">The origin of the rotation</param>
//       /// <param name="c">The angle of rotation</param>
//       abstract rotateY: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> * c: float -> vec3
//       /// <summary>Rotate a 3D vector around the z-axis</summary>
//       /// <param name="out">The receiving vec3</param>
//       /// <param name="a">The vec3 point to rotate</param>
//       /// <param name="b">The origin of the rotation</param>
//       /// <param name="c">The angle of rotation</param>
//       abstract rotateZ: out: vec3 * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> * c: float -> vec3
//       /// <summary>Perform some operation over an array of vec3s.</summary>
//       /// <param name="a">the array of vectors to iterate over</param>
//       /// <param name="stride">Number of elements between the start of each vec3. If 0 assumes tightly packed</param>
//       /// <param name="offset">Number of elements to skip at the beginning of the array</param>
//       /// <param name="count">Number of vec3s to iterate over. If 0 iterates over entire array</param>
//       /// <param name="fn">Function to call for each vector in the array</param>
//       /// <param name="arg">additional argument to pass to fn</param>
//       abstract forEach: a: Float32Array * stride: float * offset: float * count: float * fn: (U2<vec3, ResizeArray<float>> -> U2<vec3, ResizeArray<float>> -> obj option -> unit) * arg: obj option -> Float32Array
//       /// <summary>Perform some operation over an array of vec3s.</summary>
//       /// <param name="a">the array of vectors to iterate over</param>
//       /// <param name="stride">Number of elements between the start of each vec3. If 0 assumes tightly packed</param>
//       /// <param name="offset">Number of elements to skip at the beginning of the array</param>
//       /// <param name="count">Number of vec3s to iterate over. If 0 iterates over entire array</param>
//       /// <param name="fn">Function to call for each vector in the array</param>
//       abstract forEach: a: Float32Array * stride: float * offset: float * count: float * fn: (U2<vec3, ResizeArray<float>> -> U2<vec3, ResizeArray<float>> -> unit) -> Float32Array
//       /// <summary>Get the angle between two 3D vectors</summary>
//       /// <param name="a">The first operand</param>
//       /// <param name="b">The second operand</param>
//       abstract angle: a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> float
//       /// <summary>Returns a string representation of a vector</summary>
//       /// <param name="a">vector to represent as a string</param>
//       abstract str: a: U2<vec3, ResizeArray<float>> -> string
//       /// <summary>Returns whether or not the vectors have exactly the same elements in the same position (when compared with ===)</summary>
//       /// <param name="a">The first vector.</param>
//       /// <param name="b">The second vector.</param>
//       abstract exactEquals: a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> bool
//       /// <summary>Returns whether or not the vectors have approximately the same elements in the same position.</summary>
//       /// <param name="a">The first vector.</param>
//       /// <param name="b">The second vector.</param>
//       abstract equals: a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> bool

//   type vec4 =
//       inherit Float32Array

//   type [<AllowNullLiteral>] vec4Static =
//       [<Emit "new $0($1...)">] abstract Create: unit -> vec4
//       /// Creates a new, empty vec4
//       abstract create: unit -> vec4
//       /// <summary>Creates a new vec4 initialized with values from an existing vector</summary>
//       /// <param name="a">vector to clone</param>
//       abstract clone: a: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Creates a new vec4 initialized with the given values</summary>
//       /// <param name="x">X component</param>
//       /// <param name="y">Y component</param>
//       /// <param name="z">Z component</param>
//       /// <param name="w">W component</param>
//       abstract fromValues: x: float * y: float * z: float * w: float -> vec4
//       /// <summary>Copy the values from one vec4 to another</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the source vector</param>
//       abstract copy: out: vec4 * a: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Set the components of a vec4 to the given values</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="x">X component</param>
//       /// <param name="y">Y component</param>
//       /// <param name="z">Z component</param>
//       /// <param name="w">W component</param>
//       abstract set: out: vec4 * x: float * y: float * z: float * w: float -> vec4
//       /// <summary>Adds two vec4's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract add: out: vec4 * a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Subtracts vector b from vector a</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract subtract: out: vec4 * a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Subtracts vector b from vector a</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract sub: out: vec4 * a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Multiplies two vec4's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract multiply: out: vec4 * a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Multiplies two vec4's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract mul: out: vec4 * a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Divides two vec4's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract divide: out: vec4 * a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Divides two vec4's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract div: out: vec4 * a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Math.ceil the components of a vec4</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">vector to ceil</param>
//       abstract ceil: out: vec4 * a: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Math.floor the components of a vec4</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">vector to floor</param>
//       abstract floor: out: vec4 * a: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Returns the minimum of two vec4's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract min: out: vec4 * a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Returns the maximum of two vec4's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract max: out: vec4 * a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Math.round the components of a vec4</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">vector to round</param>
//       abstract round: out: vec4 * a: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Scales a vec4 by a scalar number</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the vector to scale</param>
//       /// <param name="b">amount to scale the vector by</param>
//       abstract scale: out: vec4 * a: U2<vec4, ResizeArray<float>> * b: float -> vec4
//       /// <summary>Adds two vec4's after scaling the second operand by a scalar value</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       /// <param name="scale">the amount to scale b by before adding</param>
//       abstract scaleAndAdd: out: vec4 * a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> * scale: float -> vec4
//       /// <summary>Calculates the euclidian distance between two vec4's</summary>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract distance: a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> -> float
//       /// <summary>Calculates the euclidian distance between two vec4's</summary>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract dist: a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> -> float
//       /// <summary>Calculates the squared euclidian distance between two vec4's</summary>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract squaredDistance: a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> -> float
//       /// <summary>Calculates the squared euclidian distance between two vec4's</summary>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract sqrDist: a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> -> float
//       /// <summary>Calculates the length of a vec4</summary>
//       /// <param name="a">vector to calculate length of</param>
//       abstract length: a: U2<vec4, ResizeArray<float>> -> float
//       /// <summary>Calculates the length of a vec4</summary>
//       /// <param name="a">vector to calculate length of</param>
//       abstract len: a: U2<vec4, ResizeArray<float>> -> float
//       /// <summary>Calculates the squared length of a vec4</summary>
//       /// <param name="a">vector to calculate squared length of</param>
//       abstract squaredLength: a: U2<vec4, ResizeArray<float>> -> float
//       /// <summary>Calculates the squared length of a vec4</summary>
//       /// <param name="a">vector to calculate squared length of</param>
//       abstract sqrLen: a: U2<vec4, ResizeArray<float>> -> float
//       /// <summary>Negates the components of a vec4</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">vector to negate</param>
//       abstract negate: out: vec4 * a: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Returns the inverse of the components of a vec4</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">vector to invert</param>
//       abstract inverse: out: vec4 * a: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Normalize a vec4</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">vector to normalize</param>
//       abstract normalize: out: vec4 * a: U2<vec4, ResizeArray<float>> -> vec4
//       /// <summary>Calculates the dot product of two vec4's</summary>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract dot: a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> -> float
//       /// <summary>Performs a linear interpolation between two vec4's</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       /// <param name="t">interpolation amount between the two inputs</param>
//       abstract lerp: out: vec4 * a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> * t: float -> vec4
//       /// <summary>Generates a random unit vector</summary>
//       /// <param name="out">the receiving vector</param>
//       abstract random: out: vec4 -> vec4
//       /// <summary>Generates a random vector with the given scale</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="scale">length of the resulting vector. If ommitted, a unit vector will be returned</param>
//       abstract random: out: vec4 * scale: float -> vec4
//       /// <summary>Transforms the vec4 with a mat4.</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the vector to transform</param>
//       /// <param name="m">matrix to transform with</param>
//       abstract transformMat4: out: vec4 * a: U2<vec4, ResizeArray<float>> * m: mat4 -> vec4
//       /// <summary>Transforms the vec4 with a quat</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the vector to transform</param>
//       /// <param name="q">quaternion to transform with</param>
//       abstract transformQuat: out: vec4 * a: U2<vec4, ResizeArray<float>> * q: quat -> vec4
//       /// <summary>Perform some operation over an array of vec4s.</summary>
//       /// <param name="a">the array of vectors to iterate over</param>
//       /// <param name="stride">Number of elements between the start of each vec4. If 0 assumes tightly packed</param>
//       /// <param name="offset">Number of elements to skip at the beginning of the array</param>
//       /// <param name="count">Number of vec4s to iterate over. If 0 iterates over entire array</param>
//       /// <param name="fn">Function to call for each vector in the array</param>
//       /// <param name="arg">additional argument to pass to fn</param>
//       abstract forEach: a: Float32Array * stride: float * offset: float * count: float * fn: (U2<vec4, ResizeArray<float>> -> U2<vec4, ResizeArray<float>> -> obj option -> unit) * arg: obj option -> Float32Array
//       /// <summary>Perform some operation over an array of vec4s.</summary>
//       /// <param name="a">the array of vectors to iterate over</param>
//       /// <param name="stride">Number of elements between the start of each vec4. If 0 assumes tightly packed</param>
//       /// <param name="offset">Number of elements to skip at the beginning of the array</param>
//       /// <param name="count">Number of vec4s to iterate over. If 0 iterates over entire array</param>
//       /// <param name="fn">Function to call for each vector in the array</param>
//       abstract forEach: a: Float32Array * stride: float * offset: float * count: float * fn: (U2<vec4, ResizeArray<float>> -> U2<vec4, ResizeArray<float>> -> unit) -> Float32Array
//       /// <summary>Returns a string representation of a vector</summary>
//       /// <param name="a">vector to represent as a string</param>
//       abstract str: a: U2<vec4, ResizeArray<float>> -> string
//       /// <summary>Returns whether or not the vectors have exactly the same elements in the same position (when compared with ===)</summary>
//       /// <param name="a">The first vector.</param>
//       /// <param name="b">The second vector.</param>
//       abstract exactEquals: a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> -> bool
//       /// <summary>Returns whether or not the vectors have approximately the same elements in the same position.</summary>
//       /// <param name="a">The first vector.</param>
//       /// <param name="b">The second vector.</param>
//       abstract equals: a: U2<vec4, ResizeArray<float>> * b: U2<vec4, ResizeArray<float>> -> bool

//   type mat2 =
//       inherit Float32Array

//   type [<AllowNullLiteral>] mat2Static =
//       [<Emit "new $0($1...)">] abstract Create: unit -> mat2
//       /// Creates a new identity mat2
//       abstract create: unit -> mat2
//       /// <summary>Creates a new mat2 initialized with values from an existing matrix</summary>
//       /// <param name="a">matrix to clone</param>
//       abstract clone: a: mat2 -> mat2
//       /// <summary>Copy the values from one mat2 to another</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the source matrix</param>
//       abstract copy: out: mat2 * a: mat2 -> mat2
//       /// <summary>Set a mat2 to the identity matrix</summary>
//       /// <param name="out">the receiving matrix</param>
//       abstract identity: out: mat2 -> mat2
//       /// <summary>Create a new mat2 with the given values</summary>
//       /// <param name="m00">Component in column 0, row 0 position (index 0)</param>
//       /// <param name="m01">Component in column 0, row 1 position (index 1)</param>
//       /// <param name="m10">Component in column 1, row 0 position (index 2)</param>
//       /// <param name="m11">Component in column 1, row 1 position (index 3)</param>
//       abstract fromValues: m00: float * m01: float * m10: float * m11: float -> mat2
//       /// <summary>Set the components of a mat2 to the given values</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="m00">Component in column 0, row 0 position (index 0)</param>
//       /// <param name="m01">Component in column 0, row 1 position (index 1)</param>
//       /// <param name="m10">Component in column 1, row 0 position (index 2)</param>
//       /// <param name="m11">Component in column 1, row 1 position (index 3)</param>
//       abstract set: out: mat2 * m00: float * m01: float * m10: float * m11: float -> mat2
//       /// <summary>Transpose the values of a mat2</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the source matrix</param>
//       abstract transpose: out: mat2 * a: mat2 -> mat2
//       /// <summary>Inverts a mat2</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the source matrix</param>
//       abstract invert: out: mat2 * a: mat2 -> mat2 option
//       /// <summary>Calculates the adjugate of a mat2</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the source matrix</param>
//       abstract adjoint: out: mat2 * a: mat2 -> mat2
//       /// <summary>Calculates the determinant of a mat2</summary>
//       /// <param name="a">the source matrix</param>
//       abstract determinant: a: mat2 -> float
//       /// <summary>Multiplies two mat2's</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract multiply: out: mat2 * a: mat2 * b: mat2 -> mat2
//       /// <summary>Multiplies two mat2's</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract mul: out: mat2 * a: mat2 * b: mat2 -> mat2
//       /// <summary>Rotates a mat2 by the given angle</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to rotate</param>
//       /// <param name="rad">the angle to rotate the matrix by</param>
//       abstract rotate: out: mat2 * a: mat2 * rad: float -> mat2
//       /// <summary>Scales the mat2 by the dimensions in the given vec2</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to rotate</param>
//       /// <param name="v">the vec2 to scale the matrix by</param>
//       abstract scale: out: mat2 * a: mat2 * v: U2<vec2, ResizeArray<float>> -> mat2
//       /// <summary>Creates a matrix from a given angle
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat2.identity(dest);
//       ///      mat2.rotate(dest, dest, rad);</summary>
//       /// <param name="out">mat2 receiving operation result</param>
//       /// <param name="rad">the angle to rotate the matrix by</param>
//       abstract fromRotation: out: mat2 * rad: float -> mat2
//       /// <summary>Creates a matrix from a vector scaling
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat2.identity(dest);
//       ///      mat2.scale(dest, dest, vec);</summary>
//       /// <param name="out">mat2 receiving operation result</param>
//       /// <param name="v">Scaling vector</param>
//       abstract fromScaling: out: mat2 * v: U2<vec2, ResizeArray<float>> -> mat2
//       /// <summary>Returns a string representation of a mat2</summary>
//       /// <param name="a">matrix to represent as a string</param>
//       abstract str: a: mat2 -> string
//       /// <summary>Returns Frobenius norm of a mat2</summary>
//       /// <param name="a">the matrix to calculate Frobenius norm of</param>
//       abstract frob: a: mat2 -> float
//       /// <summary>Returns L, D and U matrices (Lower triangular, Diagonal and Upper triangular) by factorizing the input matrix</summary>
//       /// <param name="L">the lower triangular matrix</param>
//       /// <param name="D">the diagonal matrix</param>
//       /// <param name="U">the upper triangular matrix</param>
//       /// <param name="a">the input matrix to factorize</param>
//       abstract LDU: L: mat2 * D: mat2 * U: mat2 * a: mat2 -> mat2
//       /// <summary>Adds two mat2's</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract add: out: mat2 * a: mat2 * b: mat2 -> mat2
//       /// <summary>Subtracts matrix b from matrix a</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract subtract: out: mat2 * a: mat2 * b: mat2 -> mat2
//       /// <summary>Subtracts matrix b from matrix a</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract sub: out: mat2 * a: mat2 * b: mat2 -> mat2
//       /// <summary>Returns whether or not the matrices have exactly the same elements in the same position (when compared with ===)</summary>
//       /// <param name="a">The first matrix.</param>
//       /// <param name="b">The second matrix.</param>
//       abstract exactEquals: a: mat2 * b: mat2 -> bool
//       /// <summary>Returns whether or not the matrices have approximately the same elements in the same position.</summary>
//       /// <param name="a">The first matrix.</param>
//       /// <param name="b">The second matrix.</param>
//       abstract equals: a: mat2 * b: mat2 -> bool
//       /// <summary>Multiply each element of the matrix by a scalar.</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to scale</param>
//       /// <param name="b">amount to scale the matrix's elements by</param>
//       abstract multiplyScalar: out: mat2 * a: mat2 * b: float -> mat2
//       /// <summary>Adds two mat2's after multiplying each element of the second operand by a scalar value.</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       /// <param name="scale">the amount to scale b's elements by before adding</param>
//       abstract multiplyScalarAndAdd: out: mat2 * a: mat2 * b: mat2 * scale: float -> mat2

//   type mat2d =
//       inherit Float32Array

//   type [<AllowNullLiteral>] mat2dStatic =
//       [<Emit "new $0($1...)">] abstract Create: unit -> mat2d
//       /// Creates a new identity mat2d
//       abstract create: unit -> mat2d
//       /// <summary>Creates a new mat2d initialized with values from an existing matrix</summary>
//       /// <param name="a">matrix to clone</param>
//       abstract clone: a: mat2d -> mat2d
//       /// <summary>Copy the values from one mat2d to another</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the source matrix</param>
//       abstract copy: out: mat2d * a: mat2d -> mat2d
//       /// <summary>Set a mat2d to the identity matrix</summary>
//       /// <param name="out">the receiving matrix</param>
//       abstract identity: out: mat2d -> mat2d
//       /// <summary>Create a new mat2d with the given values</summary>
//       /// <param name="a">Component A (index 0)</param>
//       /// <param name="b">Component B (index 1)</param>
//       /// <param name="c">Component C (index 2)</param>
//       /// <param name="d">Component D (index 3)</param>
//       /// <param name="tx">Component TX (index 4)</param>
//       /// <param name="ty">Component TY (index 5)</param>
//       abstract fromValues: a: float * b: float * c: float * d: float * tx: float * ty: float -> mat2d
//       /// <summary>Set the components of a mat2d to the given values</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">Component A (index 0)</param>
//       /// <param name="b">Component B (index 1)</param>
//       /// <param name="c">Component C (index 2)</param>
//       /// <param name="d">Component D (index 3)</param>
//       /// <param name="tx">Component TX (index 4)</param>
//       /// <param name="ty">Component TY (index 5)</param>
//       abstract set: out: mat2d * a: float * b: float * c: float * d: float * tx: float * ty: float -> mat2d
//       /// <summary>Inverts a mat2d</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the source matrix</param>
//       abstract invert: out: mat2d * a: mat2d -> mat2d option
//       /// <summary>Calculates the determinant of a mat2d</summary>
//       /// <param name="a">the source matrix</param>
//       abstract determinant: a: mat2d -> float
//       /// <summary>Multiplies two mat2d's</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract multiply: out: mat2d * a: mat2d * b: mat2d -> mat2d
//       /// <summary>Multiplies two mat2d's</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract mul: out: mat2d * a: mat2d * b: mat2d -> mat2d
//       /// <summary>Rotates a mat2d by the given angle</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to rotate</param>
//       /// <param name="rad">the angle to rotate the matrix by</param>
//       abstract rotate: out: mat2d * a: mat2d * rad: float -> mat2d
//       /// <summary>Scales the mat2d by the dimensions in the given vec2</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to translate</param>
//       /// <param name="v">the vec2 to scale the matrix by</param>
//       abstract scale: out: mat2d * a: mat2d * v: U2<vec2, ResizeArray<float>> -> mat2d
//       /// <summary>Translates the mat2d by the dimensions in the given vec2</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to translate</param>
//       /// <param name="v">the vec2 to translate the matrix by</param>
//       abstract translate: out: mat2d * a: mat2d * v: U2<vec2, ResizeArray<float>> -> mat2d
//       /// <summary>Creates a matrix from a given angle
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat2d.identity(dest);
//       ///      mat2d.rotate(dest, dest, rad);</summary>
//       /// <param name="out">mat2d receiving operation result</param>
//       /// <param name="rad">the angle to rotate the matrix by</param>
//       abstract fromRotation: out: mat2d * rad: float -> mat2d
//       /// <summary>Creates a matrix from a vector scaling
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat2d.identity(dest);
//       ///      mat2d.scale(dest, dest, vec);</summary>
//       /// <param name="out">mat2d receiving operation result</param>
//       /// <param name="v">Scaling vector</param>
//       abstract fromScaling: out: mat2d * v: U2<vec2, ResizeArray<float>> -> mat2d
//       /// <summary>Creates a matrix from a vector translation
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat2d.identity(dest);
//       ///      mat2d.translate(dest, dest, vec);</summary>
//       /// <param name="out">mat2d receiving operation result</param>
//       /// <param name="v">Translation vector</param>
//       abstract fromTranslation: out: mat2d * v: U2<vec2, ResizeArray<float>> -> mat2d
//       /// <summary>Returns a string representation of a mat2d</summary>
//       /// <param name="a">matrix to represent as a string</param>
//       abstract str: a: mat2d -> string
//       /// <summary>Returns Frobenius norm of a mat2d</summary>
//       /// <param name="a">the matrix to calculate Frobenius norm of</param>
//       abstract frob: a: mat2d -> float
//       /// <summary>Adds two mat2d's</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract add: out: mat2d * a: mat2d * b: mat2d -> mat2d
//       /// <summary>Subtracts matrix b from matrix a</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract subtract: out: mat2d * a: mat2d * b: mat2d -> mat2d
//       /// <summary>Subtracts matrix b from matrix a</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract sub: out: mat2d * a: mat2d * b: mat2d -> mat2d
//       /// <summary>Multiply each element of the matrix by a scalar.</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to scale</param>
//       /// <param name="b">amount to scale the matrix's elements by</param>
//       abstract multiplyScalar: out: mat2d * a: mat2d * b: float -> mat2d
//       /// <summary>Adds two mat2d's after multiplying each element of the second operand by a scalar value.</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       /// <param name="scale">the amount to scale b's elements by before adding</param>
//       abstract multiplyScalarAndAdd: out: mat2d * a: mat2d * b: mat2d * scale: float -> mat2d
//       /// <summary>Returns whether or not the matrices have exactly the same elements in the same position (when compared with ===)</summary>
//       /// <param name="a">The first matrix.</param>
//       /// <param name="b">The second matrix.</param>
//       abstract exactEquals: a: mat2d * b: mat2d -> bool
//       /// <summary>Returns whether or not the matrices have approximately the same elements in the same position.</summary>
//       /// <param name="a">The first matrix.</param>
//       /// <param name="b">The second matrix.</param>
//       abstract equals: a: mat2d * b: mat2d -> bool

//   type mat3 =
//       inherit Float32Array

//   type [<AllowNullLiteral>] mat3Static =
//       [<Emit "new $0($1...)">] abstract Create: unit -> mat3
//       /// Creates a new identity mat3
//       abstract create: unit -> mat3
//       /// <summary>Copies the upper-left 3x3 values into the given mat3.</summary>
//       /// <param name="out">the receiving 3x3 matrix</param>
//       /// <param name="a">the source 4x4 matrix</param>
//       abstract fromMat4: out: mat3 * a: mat4 -> mat3
//       /// <summary>Creates a new mat3 initialized with values from an existing matrix</summary>
//       /// <param name="a">matrix to clone</param>
//       abstract clone: a: mat3 -> mat3
//       /// <summary>Copy the values from one mat3 to another</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the source matrix</param>
//       abstract copy: out: mat3 * a: mat3 -> mat3
//       /// <summary>Create a new mat3 with the given values</summary>
//       /// <param name="m00">Component in column 0, row 0 position (index 0)</param>
//       /// <param name="m01">Component in column 0, row 1 position (index 1)</param>
//       /// <param name="m02">Component in column 0, row 2 position (index 2)</param>
//       /// <param name="m10">Component in column 1, row 0 position (index 3)</param>
//       /// <param name="m11">Component in column 1, row 1 position (index 4)</param>
//       /// <param name="m12">Component in column 1, row 2 position (index 5)</param>
//       /// <param name="m20">Component in column 2, row 0 position (index 6)</param>
//       /// <param name="m21">Component in column 2, row 1 position (index 7)</param>
//       /// <param name="m22">Component in column 2, row 2 position (index 8)</param>
//       abstract fromValues: m00: float * m01: float * m02: float * m10: float * m11: float * m12: float * m20: float * m21: float * m22: float -> mat3
//       /// <summary>Set the components of a mat3 to the given values</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="m00">Component in column 0, row 0 position (index 0)</param>
//       /// <param name="m01">Component in column 0, row 1 position (index 1)</param>
//       /// <param name="m02">Component in column 0, row 2 position (index 2)</param>
//       /// <param name="m10">Component in column 1, row 0 position (index 3)</param>
//       /// <param name="m11">Component in column 1, row 1 position (index 4)</param>
//       /// <param name="m12">Component in column 1, row 2 position (index 5)</param>
//       /// <param name="m20">Component in column 2, row 0 position (index 6)</param>
//       /// <param name="m21">Component in column 2, row 1 position (index 7)</param>
//       /// <param name="m22">Component in column 2, row 2 position (index 8)</param>
//       abstract set: out: mat3 * m00: float * m01: float * m02: float * m10: float * m11: float * m12: float * m20: float * m21: float * m22: float -> mat3
//       /// <summary>Set a mat3 to the identity matrix</summary>
//       /// <param name="out">the receiving matrix</param>
//       abstract identity: out: mat3 -> mat3
//       /// <summary>Transpose the values of a mat3</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the source matrix</param>
//       abstract transpose: out: mat3 * a: mat3 -> mat3
//       /// <summary>Generates a 2D projection matrix with the given bounds</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="width">width of your gl context</param>
//       /// <param name="height">height of gl context</param>
//       abstract projection: out: mat3 * width: float * height: float -> mat3
//       /// <summary>Inverts a mat3</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the source matrix</param>
//       abstract invert: out: mat3 * a: mat3 -> mat3 option
//       /// <summary>Calculates the adjugate of a mat3</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the source matrix</param>
//       abstract adjoint: out: mat3 * a: mat3 -> mat3
//       /// <summary>Calculates the determinant of a mat3</summary>
//       /// <param name="a">the source matrix</param>
//       abstract determinant: a: mat3 -> float
//       /// <summary>Multiplies two mat3's</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract multiply: out: mat3 * a: mat3 * b: mat3 -> mat3
//       /// <summary>Multiplies two mat3's</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract mul: out: mat3 * a: mat3 * b: mat3 -> mat3
//       /// <summary>Translate a mat3 by the given vector</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to translate</param>
//       /// <param name="v">vector to translate by</param>
//       abstract translate: out: mat3 * a: mat3 * v: U2<vec2, ResizeArray<float>> -> mat3
//       /// <summary>Rotates a mat3 by the given angle</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to rotate</param>
//       /// <param name="rad">the angle to rotate the matrix by</param>
//       abstract rotate: out: mat3 * a: mat3 * rad: float -> mat3
//       /// <summary>Scales the mat3 by the dimensions in the given vec2</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to rotate</param>
//       /// <param name="v">the vec2 to scale the matrix by</param>
//       abstract scale: out: mat3 * a: mat3 * v: U2<vec2, ResizeArray<float>> -> mat3
//       /// <summary>Creates a matrix from a vector translation
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat3.identity(dest);
//       ///      mat3.translate(dest, dest, vec);</summary>
//       /// <param name="out">mat3 receiving operation result</param>
//       /// <param name="v">Translation vector</param>
//       abstract fromTranslation: out: mat3 * v: U2<vec2, ResizeArray<float>> -> mat3
//       /// <summary>Creates a matrix from a given angle
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat3.identity(dest);
//       ///      mat3.rotate(dest, dest, rad);</summary>
//       /// <param name="out">mat3 receiving operation result</param>
//       /// <param name="rad">the angle to rotate the matrix by</param>
//       abstract fromRotation: out: mat3 * rad: float -> mat3
//       /// <summary>Creates a matrix from a vector scaling
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat3.identity(dest);
//       ///      mat3.scale(dest, dest, vec);</summary>
//       /// <param name="out">mat3 receiving operation result</param>
//       /// <param name="v">Scaling vector</param>
//       abstract fromScaling: out: mat3 * v: U2<vec2, ResizeArray<float>> -> mat3
//       /// <summary>Copies the values from a mat2d into a mat3</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to copy</param>
//       abstract fromMat2d: out: mat3 * a: mat2d -> mat3
//       /// <summary>Calculates a 3x3 matrix from the given quaternion</summary>
//       /// <param name="out">mat3 receiving operation result</param>
//       /// <param name="q">Quaternion to create matrix from</param>
//       abstract fromQuat: out: mat3 * q: quat -> mat3
//       /// <summary>Calculates a 3x3 normal matrix (transpose inverse) from the 4x4 matrix</summary>
//       /// <param name="out">mat3 receiving operation result</param>
//       /// <param name="a">Mat4 to derive the normal matrix from</param>
//       abstract normalFromMat4: out: mat3 * a: mat4 -> mat3 option
//       /// <summary>Returns a string representation of a mat3</summary>
//       /// <param name="mat">matrix to represent as a string</param>
//       abstract str: mat: mat3 -> string
//       /// <summary>Returns Frobenius norm of a mat3</summary>
//       /// <param name="a">the matrix to calculate Frobenius norm of</param>
//       abstract frob: a: mat3 -> float
//       /// <summary>Adds two mat3's</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract add: out: mat3 * a: mat3 * b: mat3 -> mat3
//       /// <summary>Subtracts matrix b from matrix a</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract subtract: out: mat3 * a: mat3 * b: mat3 -> mat3
//       /// <summary>Subtracts matrix b from matrix a</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract sub: out: mat3 * a: mat3 * b: mat3 -> mat3
//       /// <summary>Multiply each element of the matrix by a scalar.</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to scale</param>
//       /// <param name="b">amount to scale the matrix's elements by</param>
//       abstract multiplyScalar: out: mat3 * a: mat3 * b: float -> mat3
//       /// <summary>Adds two mat3's after multiplying each element of the second operand by a scalar value.</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       /// <param name="scale">the amount to scale b's elements by before adding</param>
//       abstract multiplyScalarAndAdd: out: mat3 * a: mat3 * b: mat3 * scale: float -> mat3
//       /// <summary>Returns whether or not the matrices have exactly the same elements in the same position (when compared with ===)</summary>
//       /// <param name="a">The first matrix.</param>
//       /// <param name="b">The second matrix.</param>
//       abstract exactEquals: a: mat3 * b: mat3 -> bool
//       /// <summary>Returns whether or not the matrices have approximately the same elements in the same position.</summary>
//       /// <param name="a">The first matrix.</param>
//       /// <param name="b">The second matrix.</param>
//       abstract equals: a: mat3 * b: mat3 -> bool

//   type mat4 =
//       inherit Float32Array

//   type [<AllowNullLiteral>] mat4Static =
//       [<Emit "new $0($1...)">] abstract Create: unit -> mat4
//       /// Creates a new identity mat4
//       abstract create: unit -> mat4
//       /// <summary>Creates a new mat4 initialized with values from an existing matrix</summary>
//       /// <param name="a">matrix to clone</param>
//       abstract clone: a: mat4 -> mat4
//       /// <summary>Copy the values from one mat4 to another</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the source matrix</param>
//       abstract copy: out: mat4 * a: mat4 -> mat4
//       /// <summary>Create a new mat4 with the given values</summary>
//       /// <param name="m00">Component in column 0, row 0 position (index 0)</param>
//       /// <param name="m01">Component in column 0, row 1 position (index 1)</param>
//       /// <param name="m02">Component in column 0, row 2 position (index 2)</param>
//       /// <param name="m03">Component in column 0, row 3 position (index 3)</param>
//       /// <param name="m10">Component in column 1, row 0 position (index 4)</param>
//       /// <param name="m11">Component in column 1, row 1 position (index 5)</param>
//       /// <param name="m12">Component in column 1, row 2 position (index 6)</param>
//       /// <param name="m13">Component in column 1, row 3 position (index 7)</param>
//       /// <param name="m20">Component in column 2, row 0 position (index 8)</param>
//       /// <param name="m21">Component in column 2, row 1 position (index 9)</param>
//       /// <param name="m22">Component in column 2, row 2 position (index 10)</param>
//       /// <param name="m23">Component in column 2, row 3 position (index 11)</param>
//       /// <param name="m30">Component in column 3, row 0 position (index 12)</param>
//       /// <param name="m31">Component in column 3, row 1 position (index 13)</param>
//       /// <param name="m32">Component in column 3, row 2 position (index 14)</param>
//       /// <param name="m33">Component in column 3, row 3 position (index 15)</param>
//       abstract fromValues: m00: float * m01: float * m02: float * m03: float * m10: float * m11: float * m12: float * m13: float * m20: float * m21: float * m22: float * m23: float * m30: float * m31: float * m32: float * m33: float -> mat4
//       /// <summary>Set the components of a mat4 to the given values</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="m00">Component in column 0, row 0 position (index 0)</param>
//       /// <param name="m01">Component in column 0, row 1 position (index 1)</param>
//       /// <param name="m02">Component in column 0, row 2 position (index 2)</param>
//       /// <param name="m03">Component in column 0, row 3 position (index 3)</param>
//       /// <param name="m10">Component in column 1, row 0 position (index 4)</param>
//       /// <param name="m11">Component in column 1, row 1 position (index 5)</param>
//       /// <param name="m12">Component in column 1, row 2 position (index 6)</param>
//       /// <param name="m13">Component in column 1, row 3 position (index 7)</param>
//       /// <param name="m20">Component in column 2, row 0 position (index 8)</param>
//       /// <param name="m21">Component in column 2, row 1 position (index 9)</param>
//       /// <param name="m22">Component in column 2, row 2 position (index 10)</param>
//       /// <param name="m23">Component in column 2, row 3 position (index 11)</param>
//       /// <param name="m30">Component in column 3, row 0 position (index 12)</param>
//       /// <param name="m31">Component in column 3, row 1 position (index 13)</param>
//       /// <param name="m32">Component in column 3, row 2 position (index 14)</param>
//       /// <param name="m33">Component in column 3, row 3 position (index 15)</param>
//       abstract set: out: mat4 * m00: float * m01: float * m02: float * m03: float * m10: float * m11: float * m12: float * m13: float * m20: float * m21: float * m22: float * m23: float * m30: float * m31: float * m32: float * m33: float -> mat4
//       /// <summary>Set a mat4 to the identity matrix</summary>
//       /// <param name="out">the receiving matrix</param>
//       abstract identity: out: mat4 -> mat4
//       /// <summary>Transpose the values of a mat4</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the source matrix</param>
//       abstract transpose: out: mat4 * a: mat4 -> mat4
//       /// <summary>Inverts a mat4</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the source matrix</param>
//       abstract invert: out: mat4 * a: mat4 -> mat4 option
//       /// <summary>Calculates the adjugate of a mat4</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the source matrix</param>
//       abstract adjoint: out: mat4 * a: mat4 -> mat4
//       /// <summary>Calculates the determinant of a mat4</summary>
//       /// <param name="a">the source matrix</param>
//       abstract determinant: a: mat4 -> float
//       /// <summary>Multiplies two mat4's</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract multiply: out: mat4 * a: mat4 * b: mat4 -> mat4
//       /// <summary>Multiplies two mat4's</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract mul: out: mat4 * a: mat4 * b: mat4 -> mat4
//       /// <summary>Translate a mat4 by the given vector</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to translate</param>
//       /// <param name="v">vector to translate by</param>
//       abstract translate: out: mat4 * a: mat4 * v: U2<vec3, ResizeArray<float>> -> mat4
//       /// <summary>Scales the mat4 by the dimensions in the given vec3</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to scale</param>
//       /// <param name="v">the vec3 to scale the matrix by</param>
//       abstract scale: out: mat4 * a: mat4 * v: U2<vec3, ResizeArray<float>> -> mat4
//       /// <summary>Rotates a mat4 by the given angle</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to rotate</param>
//       /// <param name="rad">the angle to rotate the matrix by</param>
//       /// <param name="axis">the axis to rotate around</param>
//       abstract rotate: out: mat4 * a: mat4 * rad: float * axis: U2<vec3, ResizeArray<float>> -> mat4
//       /// <summary>Rotates a matrix by the given angle around the X axis</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to rotate</param>
//       /// <param name="rad">the angle to rotate the matrix by</param>
//       abstract rotateX: out: mat4 * a: mat4 * rad: float -> mat4
//       /// <summary>Rotates a matrix by the given angle around the Y axis</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to rotate</param>
//       /// <param name="rad">the angle to rotate the matrix by</param>
//       abstract rotateY: out: mat4 * a: mat4 * rad: float -> mat4
//       /// <summary>Rotates a matrix by the given angle around the Z axis</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to rotate</param>
//       /// <param name="rad">the angle to rotate the matrix by</param>
//       abstract rotateZ: out: mat4 * a: mat4 * rad: float -> mat4
//       /// <summary>Creates a matrix from a vector translation
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat4.identity(dest);
//       ///      mat4.translate(dest, dest, vec);</summary>
//       /// <param name="out">mat4 receiving operation result</param>
//       /// <param name="v">Translation vector</param>
//       abstract fromTranslation: out: mat4 * v: U2<vec3, ResizeArray<float>> -> mat4
//       /// <summary>Creates a matrix from a vector scaling
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat4.identity(dest);
//       ///      mat4.scale(dest, dest, vec);</summary>
//       /// <param name="out">mat4 receiving operation result</param>
//       /// <param name="v">Scaling vector</param>
//       abstract fromScaling: out: mat4 * v: U2<vec3, ResizeArray<float>> -> mat4
//       /// <summary>Creates a matrix from a given angle around a given axis
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat4.identity(dest);
//       ///      mat4.rotate(dest, dest, rad, axis);</summary>
//       /// <param name="out">mat4 receiving operation result</param>
//       /// <param name="rad">the angle to rotate the matrix by</param>
//       /// <param name="axis">the axis to rotate around</param>
//       abstract fromRotation: out: mat4 * rad: float * axis: U2<vec3, ResizeArray<float>> -> mat4
//       /// <summary>Creates a matrix from the given angle around the X axis
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat4.identity(dest);
//       ///      mat4.rotateX(dest, dest, rad);</summary>
//       /// <param name="out">mat4 receiving operation result</param>
//       /// <param name="rad">the angle to rotate the matrix by</param>
//       abstract fromXRotation: out: mat4 * rad: float -> mat4
//       /// <summary>Creates a matrix from the given angle around the Y axis
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat4.identity(dest);
//       ///      mat4.rotateY(dest, dest, rad);</summary>
//       /// <param name="out">mat4 receiving operation result</param>
//       /// <param name="rad">the angle to rotate the matrix by</param>
//       abstract fromYRotation: out: mat4 * rad: float -> mat4
//       /// <summary>Creates a matrix from the given angle around the Z axis
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat4.identity(dest);
//       ///      mat4.rotateZ(dest, dest, rad);</summary>
//       /// <param name="out">mat4 receiving operation result</param>
//       /// <param name="rad">the angle to rotate the matrix by</param>
//       abstract fromZRotation: out: mat4 * rad: float -> mat4
//       /// <summary>Creates a matrix from a quaternion rotation and vector translation
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat4.identity(dest);
//       ///      mat4.translate(dest, vec);
//       ///      var quatMat = mat4.create();
//       ///      quat4.toMat4(quat, quatMat);
//       ///      mat4.multiply(dest, quatMat);</summary>
//       /// <param name="out">mat4 receiving operation result</param>
//       /// <param name="q">Rotation quaternion</param>
//       /// <param name="v">Translation vector</param>
//       abstract fromRotationTranslation: out: mat4 * q: quat * v: U2<vec3, ResizeArray<float>> -> mat4
//       /// <summary>Returns the translation vector component of a transformation
//       ///   matrix. If a matrix is built with fromRotationTranslation,
//       ///   the returned vector will be the same as the translation vector
//       ///   originally supplied.</summary>
//       /// <param name="out">Vector to receive translation component</param>
//       /// <param name="mat">Matrix to be decomposed (input)</param>
//       abstract getTranslation: out: vec3 * mat: mat4 -> vec3
//       /// <summary>Returns the scaling factor component of a transformation matrix.
//       /// If a matrix is built with fromRotationTranslationScale with a
//       /// normalized Quaternion parameter, the returned vector will be
//       /// the same as the scaling vector originally supplied.</summary>
//       /// <param name="out">Vector to receive scaling factor component</param>
//       /// <param name="mat">Matrix to be decomposed (input)</param>
//       abstract getScaling: out: vec3 * mat: mat4 -> vec3
//       /// <summary>Returns a quaternion representing the rotational component
//       ///   of a transformation matrix. If a matrix is built with
//       ///   fromRotationTranslation, the returned quaternion will be the
//       ///   same as the quaternion originally supplied.</summary>
//       /// <param name="out">Quaternion to receive the rotation component</param>
//       /// <param name="mat">Matrix to be decomposed (input)</param>
//       abstract getRotation: out: quat * mat: mat4 -> quat
//       /// <summary>Creates a matrix from a quaternion rotation, vector translation and vector scale
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat4.identity(dest);
//       ///      mat4.translate(dest, vec);
//       ///      var quatMat = mat4.create();
//       ///      quat4.toMat4(quat, quatMat);
//       ///      mat4.multiply(dest, quatMat);
//       ///      mat4.scale(dest, scale)</summary>
//       /// <param name="out">mat4 receiving operation result</param>
//       /// <param name="q">Rotation quaternion</param>
//       /// <param name="v">Translation vector</param>
//       /// <param name="s">Scaling vector</param>
//       abstract fromRotationTranslationScale: out: mat4 * q: quat * v: U2<vec3, ResizeArray<float>> * s: U2<vec3, ResizeArray<float>> -> mat4
//       /// <summary>Creates a matrix from a quaternion rotation, vector translation and vector scale, rotating and scaling around the given origin
//       /// This is equivalent to (but much faster than):
//       /// 
//       ///      mat4.identity(dest);
//       ///      mat4.translate(dest, vec);
//       ///      mat4.translate(dest, origin);
//       ///      var quatMat = mat4.create();
//       ///      quat4.toMat4(quat, quatMat);
//       ///      mat4.multiply(dest, quatMat);
//       ///      mat4.scale(dest, scale)
//       ///      mat4.translate(dest, negativeOrigin);</summary>
//       /// <param name="out">mat4 receiving operation result</param>
//       /// <param name="q">Rotation quaternion</param>
//       /// <param name="v">Translation vector</param>
//       /// <param name="s">Scaling vector</param>
//       /// <param name="o">The origin vector around which to scale and rotate</param>
//       abstract fromRotationTranslationScaleOrigin: out: mat4 * q: quat * v: U2<vec3, ResizeArray<float>> * s: U2<vec3, ResizeArray<float>> * o: U2<vec3, ResizeArray<float>> -> mat4
//       /// <summary>Calculates a 4x4 matrix from the given quaternion</summary>
//       /// <param name="out">mat4 receiving operation result</param>
//       /// <param name="q">Quaternion to create matrix from</param>
//       abstract fromQuat: out: mat4 * q: quat -> mat4
//       /// <summary>Generates a frustum matrix with the given bounds</summary>
//       /// <param name="out">mat4 frustum matrix will be written into</param>
//       /// <param name="left">Left bound of the frustum</param>
//       /// <param name="right">Right bound of the frustum</param>
//       /// <param name="bottom">Bottom bound of the frustum</param>
//       /// <param name="top">Top bound of the frustum</param>
//       /// <param name="near">Near bound of the frustum</param>
//       /// <param name="far">Far bound of the frustum</param>
//       abstract frustum: out: mat4 * left: float * right: float * bottom: float * top: float * near: float * far: float -> mat4
//       /// <summary>Generates a perspective projection matrix with the given bounds</summary>
//       /// <param name="out">mat4 frustum matrix will be written into</param>
//       /// <param name="fovy">Vertical field of view in radians</param>
//       /// <param name="aspect">Aspect ratio. typically viewport width/height</param>
//       /// <param name="near">Near bound of the frustum</param>
//       /// <param name="far">Far bound of the frustum</param>
//       abstract perspective: out: mat4 * fovy: float * aspect: float * near: float * far: float -> mat4
//       /// <summary>Generates a perspective projection matrix with the given field of view.
//       /// This is primarily useful for generating projection matrices to be used
//       /// with the still experimental WebVR API.</summary>
//       /// <param name="out">mat4 frustum matrix will be written into</param>
//       /// <param name="fov">Object containing the following values: upDegrees, downDegrees, leftDegrees, rightDegrees</param>
//       /// <param name="near">Near bound of the frustum</param>
//       /// <param name="far">Far bound of the frustum</param>
//       abstract perspectiveFromFieldOfView: out: mat4 * fov: Mat4StaticPerspectiveFromFieldOfViewFov * near: float * far: float -> mat4
//       /// <summary>Generates a orthogonal projection matrix with the given bounds</summary>
//       /// <param name="out">mat4 frustum matrix will be written into</param>
//       /// <param name="left">Left bound of the frustum</param>
//       /// <param name="right">Right bound of the frustum</param>
//       /// <param name="bottom">Bottom bound of the frustum</param>
//       /// <param name="top">Top bound of the frustum</param>
//       /// <param name="near">Near bound of the frustum</param>
//       /// <param name="far">Far bound of the frustum</param>
//       abstract ortho: out: mat4 * left: float * right: float * bottom: float * top: float * near: float * far: float -> mat4
//       /// <summary>Generates a look-at matrix with the given eye position, focal point, and up axis</summary>
//       /// <param name="out">mat4 frustum matrix will be written into</param>
//       /// <param name="eye">Position of the viewer</param>
//       /// <param name="center">Point the viewer is looking at</param>
//       /// <param name="up">vec3 pointing up</param>
//       abstract lookAt: out: mat4 * eye: U2<vec3, ResizeArray<float>> * center: U2<vec3, ResizeArray<float>> * up: U2<vec3, ResizeArray<float>> -> mat4
//       /// <summary>Generates a matrix that makes something look at something else.</summary>
//       /// <param name="out">mat4 frustum matrix will be written into</param>
//       /// <param name="eye">Position of the viewer</param>
//       /// <param name="target">Point the viewer is looking at</param>
//       /// <param name="up">vec3 pointing up</param>
//       abstract targetTo: out: mat4 * eye: U2<vec3, ResizeArray<float>> * target: U2<vec3, ResizeArray<float>> * up: U2<vec3, ResizeArray<float>> -> mat4
//       /// <summary>Returns a string representation of a mat4</summary>
//       /// <param name="mat">matrix to represent as a string</param>
//       abstract str: mat: mat4 -> string
//       /// <summary>Returns Frobenius norm of a mat4</summary>
//       /// <param name="a">the matrix to calculate Frobenius norm of</param>
//       abstract frob: a: mat4 -> float
//       /// <summary>Adds two mat4's</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract add: out: mat4 * a: mat4 * b: mat4 -> mat4
//       /// <summary>Subtracts matrix b from matrix a</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract subtract: out: mat4 * a: mat4 * b: mat4 -> mat4
//       /// <summary>Subtracts matrix b from matrix a</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract sub: out: mat4 * a: mat4 * b: mat4 -> mat4
//       /// <summary>Multiply each element of the matrix by a scalar.</summary>
//       /// <param name="out">the receiving matrix</param>
//       /// <param name="a">the matrix to scale</param>
//       /// <param name="b">amount to scale the matrix's elements by</param>
//       abstract multiplyScalar: out: mat4 * a: mat4 * b: float -> mat4
//       /// <summary>Adds two mat4's after multiplying each element of the second operand by a scalar value.</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       /// <param name="scale">the amount to scale b's elements by before adding</param>
//       abstract multiplyScalarAndAdd: out: mat4 * a: mat4 * b: mat4 * scale: float -> mat4
//       /// <summary>Returns whether or not the matrices have exactly the same elements in the same position (when compared with ===)</summary>
//       /// <param name="a">The first matrix.</param>
//       /// <param name="b">The second matrix.</param>
//       abstract exactEquals: a: mat4 * b: mat4 -> bool
//       /// <summary>Returns whether or not the matrices have approximately the same elements in the same position.</summary>
//       /// <param name="a">The first matrix.</param>
//       /// <param name="b">The second matrix.</param>
//       abstract equals: a: mat4 * b: mat4 -> bool

//   type [<AllowNullLiteral>] Mat4StaticPerspectiveFromFieldOfViewFov =
//       abstract upDegrees: float with get, set
//       abstract downDegrees: float with get, set
//       abstract leftDegrees: float with get, set
//       abstract rightDegrees: float with get, set

//   type quat =
//       inherit Float32Array

//   type [<AllowNullLiteral>] quatStatic =
//       [<Emit "new $0($1...)">] abstract Create: unit -> quat
//       /// Creates a new identity quat
//       abstract create: unit -> quat
//       /// <summary>Creates a new quat initialized with values from an existing quaternion</summary>
//       /// <param name="a">quaternion to clone</param>
//       abstract clone: a: quat -> quat
//       /// <summary>Creates a new quat initialized with the given values</summary>
//       /// <param name="x">X component</param>
//       /// <param name="y">Y component</param>
//       /// <param name="z">Z component</param>
//       /// <param name="w">W component</param>
//       abstract fromValues: x: float * y: float * z: float * w: float -> quat
//       /// <summary>Copy the values from one quat to another</summary>
//       /// <param name="out">the receiving quaternion</param>
//       /// <param name="a">the source quaternion</param>
//       abstract copy: out: quat * a: quat -> quat
//       /// <summary>Set the components of a quat to the given values</summary>
//       /// <param name="out">the receiving quaternion</param>
//       /// <param name="x">X component</param>
//       /// <param name="y">Y component</param>
//       /// <param name="z">Z component</param>
//       /// <param name="w">W component</param>
//       abstract set: out: quat * x: float * y: float * z: float * w: float -> quat
//       /// <summary>Set a quat to the identity quaternion</summary>
//       /// <param name="out">the receiving quaternion</param>
//       abstract identity: out: quat -> quat
//       /// <summary>Sets a quaternion to represent the shortest rotation from one
//       /// vector to another.
//       /// 
//       /// Both vectors are assumed to be unit length.</summary>
//       /// <param name="out">the receiving quaternion.</param>
//       /// <param name="a">the initial vector</param>
//       /// <param name="b">the destination vector</param>
//       abstract rotationTo: out: quat * a: U2<vec3, ResizeArray<float>> * b: U2<vec3, ResizeArray<float>> -> quat
//       /// <summary>Sets the specified quaternion with values corresponding to the given
//       /// axes. Each axis is a vec3 and is expected to be unit length and
//       /// perpendicular to all other specified axes.</summary>
//       /// <param name="view">the vector representing the viewing direction</param>
//       /// <param name="right">the vector representing the local "right" direction</param>
//       /// <param name="up">the vector representing the local "up" direction</param>
//       abstract setAxes: out: quat * view: U2<vec3, ResizeArray<float>> * right: U2<vec3, ResizeArray<float>> * up: U2<vec3, ResizeArray<float>> -> quat
//       /// <summary>Sets a quat from the given angle and rotation axis,
//       /// then returns it.</summary>
//       /// <param name="out">the receiving quaternion</param>
//       /// <param name="axis">the axis around which to rotate</param>
//       /// <param name="rad">the angle in radians</param>
//       abstract setAxisAngle: out: quat * axis: U2<vec3, ResizeArray<float>> * rad: float -> quat
//       /// <summary>Gets the rotation axis and angle for a given
//       ///   quaternion. If a quaternion is created with
//       ///   setAxisAngle, this method will return the same
//       ///   values as providied in the original parameter list
//       ///   OR functionally equivalent values.
//       /// Example: The quaternion formed by axis [0, 0, 1] and
//       ///   angle -90 is the same as the quaternion formed by
//       ///   [0, 0, 1] and 270. This method favors the latter.</summary>
//       /// <param name="out_axis">Vector receiving the axis of rotation</param>
//       /// <param name="q">Quaternion to be decomposed</param>
//       abstract getAxisAngle: out_axis: U2<vec3, ResizeArray<float>> * q: quat -> float
//       /// <summary>Adds two quat's</summary>
//       /// <param name="out">the receiving quaternion</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract add: out: quat * a: quat * b: quat -> quat
//       /// <summary>Multiplies two quat's</summary>
//       /// <param name="out">the receiving quaternion</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract multiply: out: quat * a: quat * b: quat -> quat
//       /// <summary>Multiplies two quat's</summary>
//       /// <param name="out">the receiving quaternion</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract mul: out: quat * a: quat * b: quat -> quat
//       /// <summary>Scales a quat by a scalar number</summary>
//       /// <param name="out">the receiving vector</param>
//       /// <param name="a">the vector to scale</param>
//       /// <param name="b">amount to scale the vector by</param>
//       abstract scale: out: quat * a: quat * b: float -> quat
//       /// <summary>Calculates the length of a quat</summary>
//       /// <param name="a">vector to calculate length of</param>
//       abstract length: a: quat -> float
//       /// <summary>Calculates the length of a quat</summary>
//       /// <param name="a">vector to calculate length of</param>
//       abstract len: a: quat -> float
//       /// <summary>Calculates the squared length of a quat</summary>
//       /// <param name="a">vector to calculate squared length of</param>
//       abstract squaredLength: a: quat -> float
//       /// <summary>Calculates the squared length of a quat</summary>
//       /// <param name="a">vector to calculate squared length of</param>
//       abstract sqrLen: a: quat -> float
//       /// <summary>Normalize a quat</summary>
//       /// <param name="out">the receiving quaternion</param>
//       /// <param name="a">quaternion to normalize</param>
//       abstract normalize: out: quat * a: quat -> quat
//       /// <summary>Calculates the dot product of two quat's</summary>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       abstract dot: a: quat * b: quat -> float
//       /// <summary>Creates a quaternion from the given euler angle x, y, z.</summary>
//       /// <param name="out">the receiving quaternion</param>
//       /// <param name="x">Angle to rotate around X axis in degrees.</param>
//       /// <param name="y">Angle to rotate around Y axis in degrees.</param>
//       /// <param name="z">Angle to rotate around Z axis in degrees.</param>
//       abstract fromEuler: out: quat * x: float * y: float * z: float -> quat
//       /// <summary>Performs a linear interpolation between two quat's</summary>
//       /// <param name="out">the receiving quaternion</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       /// <param name="t">interpolation amount between the two inputs</param>
//       abstract lerp: out: quat * a: quat * b: quat * t: float -> quat
//       /// <summary>Performs a spherical linear interpolation between two quat</summary>
//       /// <param name="out">the receiving quaternion</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       /// <param name="t">interpolation amount between the two inputs</param>
//       abstract slerp: out: quat * a: quat * b: quat * t: float -> quat
//       /// <summary>Performs a spherical linear interpolation with two control points</summary>
//       /// <param name="out">the receiving quaternion</param>
//       /// <param name="a">the first operand</param>
//       /// <param name="b">the second operand</param>
//       /// <param name="c">the third operand</param>
//       /// <param name="d">the fourth operand</param>
//       /// <param name="t">interpolation amount</param>
//       abstract sqlerp: out: quat * a: quat * b: quat * c: quat * d: quat * t: float -> quat
//       /// <summary>Calculates the inverse of a quat</summary>
//       /// <param name="out">the receiving quaternion</param>
//       /// <param name="a">quat to calculate inverse of</param>
//       abstract invert: out: quat * a: quat -> quat
//       /// <summary>Calculates the conjugate of a quat
//       /// If the quaternion is normalized, this function is faster than quat.inverse and produces the same result.</summary>
//       /// <param name="out">the receiving quaternion</param>
//       /// <param name="a">quat to calculate conjugate of</param>
//       abstract conjugate: out: quat * a: quat -> quat
//       /// <summary>Returns a string representation of a quaternion</summary>
//       /// <param name="a">quat to represent as a string</param>
//       abstract str: a: quat -> string
//       /// <summary>Rotates a quaternion by the given angle about the X axis</summary>
//       /// <param name="out">quat receiving operation result</param>
//       /// <param name="a">quat to rotate</param>
//       /// <param name="rad">angle (in radians) to rotate</param>
//       abstract rotateX: out: quat * a: quat * rad: float -> quat
//       /// <summary>Rotates a quaternion by the given angle about the Y axis</summary>
//       /// <param name="out">quat receiving operation result</param>
//       /// <param name="a">quat to rotate</param>
//       /// <param name="rad">angle (in radians) to rotate</param>
//       abstract rotateY: out: quat * a: quat * rad: float -> quat
//       /// <summary>Rotates a quaternion by the given angle about the Z axis</summary>
//       /// <param name="out">quat receiving operation result</param>
//       /// <param name="a">quat to rotate</param>
//       /// <param name="rad">angle (in radians) to rotate</param>
//       abstract rotateZ: out: quat * a: quat * rad: float -> quat
//       /// <summary>Creates a quaternion from the given 3x3 rotation matrix.
//       /// 
//       /// NOTE: The resultant quaternion is not normalized, so you should be sure
//       /// to renormalize the quaternion yourself where necessary.</summary>
//       /// <param name="out">the receiving quaternion</param>
//       /// <param name="m">rotation matrix</param>
//       abstract fromMat3: out: quat * m: mat3 -> quat
//       /// <summary>Calculates the W component of a quat from the X, Y, and Z components.
//       /// Assumes that quaternion is 1 unit in length.
//       /// Any existing W component will be ignored.</summary>
//       /// <param name="out">the receiving quaternion</param>
//       /// <param name="a">quat to calculate W component of</param>
//       abstract calculateW: out: quat * a: quat -> quat
//       /// <summary>Returns whether or not the quaternions have exactly the same elements in the same position (when compared with ===)</summary>
//       /// <param name="a">The first vector.</param>
//       /// <param name="b">The second vector.</param>
//       abstract exactEquals: a: quat * b: quat -> bool
//       /// <summary>Returns whether or not the quaternions have approximately the same elements in the same position.</summary>
//       /// <param name="a">The first vector.</param>
//       /// <param name="b">The second vector.</param>
//       abstract equals: a: quat * b: quat -> bool

// // module Gl_matrix_src_gl_matrix_common =
// //   type glMatrix = Gl_matrix.glMatrix

// // module Gl_matrix_src_gl_matrix_vec2 =
// //   type vec2 = Gl_matrix.vec2

// // module Gl_matrix_src_gl_matrix_vec3 =
// //   type vec3 = Gl_matrix.vec3

// // module Gl_matrix_src_gl_matrix_vec4 =
// //   type vec4 = Gl_matrix.vec4

// // module Gl_matrix_src_gl_matrix_mat2 =
// //   type mat2 = Gl_matrix.mat2

// // module Gl_matrix_src_gl_matrix_mat2d =
// //   type mat2d = Gl_matrix.mat2d

// // module Gl_matrix_src_gl_matrix_mat3 =
// //   type mat3 = Gl_matrix.mat3

// // module Gl_matrix_src_gl_matrix_mat4 =
// //   type mat4 = Gl_matrix.mat4

// // module Gl_matrix_src_gl_matrix_quat =
// //   type quat = Gl_matrix.quat
