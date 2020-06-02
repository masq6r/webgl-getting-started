// Copy this file to your project folder
// Replace "##xxx##" with your own configurations
const path = require('path');
const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');

function resolve(filePath) {
  return path.join(__dirname, filePath)
}

module.exports = {
  entry: {
    webgl: resolve('webgl.fsproj'),
  },
  output: {
    filename: '[name].bundle.js',
    path: resolve('pages')
  },
  devtool: "inline-source-map",
  // The server hosting your web pages
  devServer: {
    hot: true,
    inline: true,
    disableHostCheck: true,
    compress: true,
    port: 8080,
    host: '0.0.0.0',
    publicPath: '/pages/',
    contentBase: '/pages',
    // If you need a backend API server
    proxy: {
      "/api/*": {
        target: "http://localhost:8888/",
        pathRewrite: {"^/api" : ""},
        secure: false
      }
    }
  },
  module: {
    rules: [
      {
        test: /\.css$/,
        use: ['style-loader', 'css-loader']
      },
      { test: /\.(eot|svg|ttf|woff|woff2)\w*/, 
        loader: "url-loader?limit=10000&mimetype=application/font-woff" 
      },
      {
        test: /\.fs(x|proj)?$/,
        use: "fable-loader"
      }
    ]
  },
  plugins: [
    new HtmlWebpackPlugin({
      title: "Get started with WebGL"
    }),
    new webpack.NamedModulesPlugin(),
    new webpack.HotModuleReplacementPlugin()
  ]
};