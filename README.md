# 插件介绍

二维码显示插件（SSCMS.QRCode）用于在模板中通过标签将 URL 地址生成二维码图片并展示在页面中。

### 插件文档

可以在插件文档 [https://sscms.com/docs/v7/official/qrcode/](https://sscms.com/docs/v7/official/qrcode/) 中查看插件的详细使用手册。

### 源代码

可以在源码仓库 [https://github.com/siteserver/sscms.qrcode](https://github.com/siteserver/sscms.qrcode) 中查看并获取插件的最新源代码。

### 插件主页

可以访问插件主页 [https://sscms.com/plugins/plugin.html?id=sscms.qrcode](https://sscms.com/plugins/plugin.html?id=sscms.qrcode) 获取插件详细信息。

### 基本用法

二维码插件使用 stl:qrCode 标签生成二维码，二维码的地址为当前页面地址：

```
<stl:qrCode></stl:qrCode>
```

### 指定二维码地址

可以使用 url 属性指定二维码地址：

```
<stl:qrCode url="https://sscms.com"></stl:qrCode>
```

### 指定二维码图片尺寸

可以使用 size 属性指定二维码图片尺寸：

```
<stl:qrCode size="128"></stl:qrCode>
```