module.exports = {
  outputDir: 'dist',
  assetsDir: 'static',
  devServer: {
    proxy: {
      '/api': {
        target: 'http://localhost:8080', // Use localhost for development
        changeOrigin: true,
        pathRewrite: { '^/api': '' },
      },
    },
  },
}