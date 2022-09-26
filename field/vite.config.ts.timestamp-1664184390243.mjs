// vite.config.ts
import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";
import path from "path";
import { prismjsPlugin } from "vite-plugin-prismjs";
import vuetify from "vite-plugin-vuetify";
var __vite_injected_original_dirname = "/home/thaumy/data/dev/repo/Field/field";
var vite_config_default = defineConfig({
  resolve: {
    alias: {
      "@": path.resolve(__vite_injected_original_dirname, "./src")
    }
  },
  publicDir: "./src/public",
  base: "./",
  plugins: [
    vue(),
    prismjsPlugin({
      languages: [
        "c",
        "go",
        "go-module",
        "sql",
        "coq",
        "css",
        "php",
        "cpp",
        "java",
        "html",
        "toml",
        "json",
        "json5",
        "yaml",
        "scss",
        "sass",
        "rust",
        "shell",
        "regex",
        "latex",
        "scala",
        "cmake",
        "python",
        "fsharp",
        "scheme",
        "kotlin",
        "haskell",
        "javascript",
        "typescript",
        "idris",
        "less",
        "lisp",
        "agda",
        "racket",
        "julia",
        "graphql",
        "http",
        "lua"
      ]
    }),
    vuetify({ autoImport: true })
  ]
});
export {
  vite_config_default as default
};
//# sourceMappingURL=data:application/json;base64,ewogICJ2ZXJzaW9uIjogMywKICAic291cmNlcyI6IFsidml0ZS5jb25maWcudHMiXSwKICAic291cmNlc0NvbnRlbnQiOiBbImNvbnN0IF9fdml0ZV9pbmplY3RlZF9vcmlnaW5hbF9kaXJuYW1lID0gXCIvaG9tZS90aGF1bXkvZGF0YS9kZXYvcmVwby9GaWVsZC9maWVsZFwiO2NvbnN0IF9fdml0ZV9pbmplY3RlZF9vcmlnaW5hbF9maWxlbmFtZSA9IFwiL2hvbWUvdGhhdW15L2RhdGEvZGV2L3JlcG8vRmllbGQvZmllbGQvdml0ZS5jb25maWcudHNcIjtjb25zdCBfX3ZpdGVfaW5qZWN0ZWRfb3JpZ2luYWxfaW1wb3J0X21ldGFfdXJsID0gXCJmaWxlOi8vL2hvbWUvdGhhdW15L2RhdGEvZGV2L3JlcG8vRmllbGQvZmllbGQvdml0ZS5jb25maWcudHNcIjtpbXBvcnQge2RlZmluZUNvbmZpZ30gZnJvbSAndml0ZSdcbmltcG9ydCB2dWUgZnJvbSAnQHZpdGVqcy9wbHVnaW4tdnVlJ1xuaW1wb3J0IHBhdGggZnJvbSAncGF0aCdcbmltcG9ydCB7cHJpc21qc1BsdWdpbn0gZnJvbSBcInZpdGUtcGx1Z2luLXByaXNtanNcIlxuXG4vLyBodHRwczovL2dpdGh1Yi5jb20vdnVldGlmeWpzL3Z1ZXRpZnktbG9hZGVyL3RyZWUvbmV4dC9wYWNrYWdlcy92aXRlLXBsdWdpblxuaW1wb3J0IHZ1ZXRpZnkgZnJvbSAndml0ZS1wbHVnaW4tdnVldGlmeSdcblxuLy9UT0RPIHNjc3MgdmFyaWFibGVzIHJlcGxhY2UgdmlhIHJlc29sdmVycy4uLlxuLy9pbXBvcnQgQ29tcG9uZW50cyBmcm9tICd1bnBsdWdpbi12dWUtY29tcG9uZW50cy92aXRlJ1xuLy9pbXBvcnQge1Z1ZXRpZnkzUmVzb2x2ZXJ9IGZyb20gXCJ1bnBsdWdpbi12dWUtY29tcG9uZW50cy9yZXNvbHZlcnNcIjtcblxuLy8gaHR0cHM6Ly92aXRlanMuZGV2L2NvbmZpZy9cbmV4cG9ydCBkZWZhdWx0IGRlZmluZUNvbmZpZyh7XG4gICAgcmVzb2x2ZToge1xuICAgICAgICBhbGlhczoge1xuICAgICAgICAgICAgJ0AnOiBwYXRoLnJlc29sdmUoX19kaXJuYW1lLCAnLi9zcmMnKSxcbiAgICAgICAgfSxcbiAgICB9LFxuICAgIHB1YmxpY0RpcjogJy4vc3JjL3B1YmxpYycsXG4gICAgYmFzZTogJy4vJyxcbiAgICBwbHVnaW5zOiBbXG4gICAgICAgIHZ1ZSgpLFxuICAgICAgICBwcmlzbWpzUGx1Z2luKHtcbiAgICAgICAgICAgIGxhbmd1YWdlczogW1xuICAgICAgICAgICAgICAgICdjJyxcbiAgICAgICAgICAgICAgICAnZ28nLCAnZ28tbW9kdWxlJyxcbiAgICAgICAgICAgICAgICAnc3FsJywgJ2NvcScsICdjc3MnLCAncGhwJywgJ2NwcCcsXG4gICAgICAgICAgICAgICAgJ2phdmEnLCAnaHRtbCcsICd0b21sJywgJ2pzb24nLCAnanNvbjUnLCAneWFtbCcsICdzY3NzJywgJ3Nhc3MnLCAncnVzdCcsXG4gICAgICAgICAgICAgICAgJ3NoZWxsJywgJ3JlZ2V4JywgJ2xhdGV4JywgJ3NjYWxhJywgJ2NtYWtlJyxcbiAgICAgICAgICAgICAgICAncHl0aG9uJywgJ2ZzaGFycCcsICdzY2hlbWUnLCAna290bGluJyxcbiAgICAgICAgICAgICAgICAnaGFza2VsbCcsXG4gICAgICAgICAgICAgICAgJ2phdmFzY3JpcHQnLCAndHlwZXNjcmlwdCcsXG4gICAgICAgICAgICAgICAgLy9yYXJlIHVzYWdlXG4gICAgICAgICAgICAgICAgJ2lkcmlzJywgJ2xlc3MnLCAnbGlzcCcsICdhZ2RhJywgJ3JhY2tldCcsICdqdWxpYScsICdncmFwaHFsJywgJ2h0dHAnLCAnbHVhJ1xuICAgICAgICAgICAgXSxcbiAgICAgICAgICAgIC8qVE9ETyBmaXggc3R5bGVcbiAgICAgICAgICAgIHBsdWdpbnM6IFsnc2hvdy1sYW5ndWFnZSddKi9cbiAgICAgICAgfSksXG4gICAgICAgIHZ1ZXRpZnkoe2F1dG9JbXBvcnQ6IHRydWV9KSxcbiAgICAgICAgLy9Db21wb25lbnRzKHtyZXNvbHZlcnM6IFtWdWV0aWZ5M1Jlc29sdmVyKCldfSlcbiAgICBdLFxuICAgIC8vVE9ETyBzY3NzIHZhcmlhYmxlcyByZXBsYWNlIHZpYSByZXNvbHZlcnMuLi5cbiAgICAvKlxuICAgIGNzczoge1xuICAgICAgICBwcmVwcm9jZXNzb3JPcHRpb25zOiB7XG4gICAgICAgICAgICBzYXNzOiB7XG4gICAgICAgICAgICAgICAgYWRkaXRpb25hbERhdGE6IFwiXFxuQGltcG9ydCAnLi9zcmMvc3R5bGVzL3ZhcmlhYmxlcy5zY3NzJztcXG5cIlxuICAgICAgICAgICAgfVxuICAgICAgICB9XG4gICAgfSovXG59KVxuIl0sCiAgIm1hcHBpbmdzIjogIjtBQUFvUyxTQUFRLG9CQUFtQjtBQUMvVCxPQUFPLFNBQVM7QUFDaEIsT0FBTyxVQUFVO0FBQ2pCLFNBQVEscUJBQW9CO0FBRzVCLE9BQU8sYUFBYTtBQU5wQixJQUFNLG1DQUFtQztBQWF6QyxJQUFPLHNCQUFRLGFBQWE7QUFBQSxFQUN4QixTQUFTO0FBQUEsSUFDTCxPQUFPO0FBQUEsTUFDSCxLQUFLLEtBQUssUUFBUSxrQ0FBVyxPQUFPO0FBQUEsSUFDeEM7QUFBQSxFQUNKO0FBQUEsRUFDQSxXQUFXO0FBQUEsRUFDWCxNQUFNO0FBQUEsRUFDTixTQUFTO0FBQUEsSUFDTCxJQUFJO0FBQUEsSUFDSixjQUFjO0FBQUEsTUFDVixXQUFXO0FBQUEsUUFDUDtBQUFBLFFBQ0E7QUFBQSxRQUFNO0FBQUEsUUFDTjtBQUFBLFFBQU87QUFBQSxRQUFPO0FBQUEsUUFBTztBQUFBLFFBQU87QUFBQSxRQUM1QjtBQUFBLFFBQVE7QUFBQSxRQUFRO0FBQUEsUUFBUTtBQUFBLFFBQVE7QUFBQSxRQUFTO0FBQUEsUUFBUTtBQUFBLFFBQVE7QUFBQSxRQUFRO0FBQUEsUUFDakU7QUFBQSxRQUFTO0FBQUEsUUFBUztBQUFBLFFBQVM7QUFBQSxRQUFTO0FBQUEsUUFDcEM7QUFBQSxRQUFVO0FBQUEsUUFBVTtBQUFBLFFBQVU7QUFBQSxRQUM5QjtBQUFBLFFBQ0E7QUFBQSxRQUFjO0FBQUEsUUFFZDtBQUFBLFFBQVM7QUFBQSxRQUFRO0FBQUEsUUFBUTtBQUFBLFFBQVE7QUFBQSxRQUFVO0FBQUEsUUFBUztBQUFBLFFBQVc7QUFBQSxRQUFRO0FBQUEsTUFDM0U7QUFBQSxJQUdKLENBQUM7QUFBQSxJQUNELFFBQVEsRUFBQyxZQUFZLEtBQUksQ0FBQztBQUFBLEVBRTlCO0FBVUosQ0FBQzsiLAogICJuYW1lcyI6IFtdCn0K
