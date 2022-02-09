const path = require("path");
const VueLoaderPlugin = require("vue-loader/lib/plugin");

module.exports = {
  mode: "development",
  entry: {
    statistic: "./Scripts/statistic.ts",
    home: "./Scripts/home.ts",
    login: "./Scripts/login.ts",
  },
  output: {
    path: path.resolve(__dirname, "./wwwroot/dist"),
    filename: "[name].bundle.js",
    publicPath: "wwwroot/dist/",
  },
  module: {
    rules: [
      {
        test: /\.js$/,
        use: "babel-loader",
      },
      {
        test: /\.ts$/,
        exclude: /node_modules/,
        use: [
          {
            loader: "babel-loader",
          },
          {
            loader: "ts-loader",
            options: {
              appendTsSuffixTo: [/\.vue$/],
            },
          },
        ],
      },
      {
        test: /\.vue$/,
        use: "vue-loader",
      },
      {
        test: /\.s(c|a)ss$/,
        use: [
          "vue-style-loader",
          "css-loader",
          {
            loader: "sass-loader",
            options: {
              implementation: require("sass"),
              sassOptions: {
                indentedSyntax: true,
              },
            },
          },
        ],
      },
      {
        test: /\.css$/,
        use: ["style-loader", "css-loader"],
      },
    ],
  },
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "./Components/"),
      vue$: "vue/dist/vue.esm.js",
    },
    extensions: [".js", ".vue", ".ts"],
  },
  plugins: [new VueLoaderPlugin()],
};
