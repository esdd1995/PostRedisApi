module.exports = {
  outputDir: 'dist',
  assetsDir: 'static',
  devServer: {
    host: '0.0.0.0',  // Allow access from outside the container
    port: 8080,       // Match the port exposed in the Dockerfile
    watchOptions: {
      poll: true,     // Enable polling for file changes
    },
    proxy: {
      '/api': {
        target: 'http://localhost:8080', // Use localhost for development
        changeOrigin: true,
        pathRewrite: { '^/api': '' },
      },
    },
  },
}