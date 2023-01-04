class BuildMeta {
    //config Field here
    #site_title = 'THAUMY的小站'
    #site_icon_url = 'https://cdn.thaumy.cn/ui/icon.png'
    #enable_cdn = false
    #cdn_url = 'https://cdn.thaumy.cn'

    #avatar_img_url = 'https://cdn.thaumy.cn/ui/avatar.png'
    #background_img_url = 'https://cdn.thaumy.cn/ui/background.jpg'

    #ws_server_root = 'ws://127.0.0.1:10010'
    #ws_client_root = 'ws://127.0.0.1:10011'
    //#ws_client_root = 'wss://next.thaumy.cn:10011'

    #enable_server_dev_log = true
    #enable_client_dev_log = true


    //public fields
    siteTitle = this.#site_title
    siteIconUrl = this.#site_icon_url
    cdnURL = this.#enable_cdn ? this.#cdn_url : ''

    avatarImgUrl = this.#avatar_img_url
    backgroundImgUrl = this.#background_img_url

    wsServerRoot = this.#ws_server_root
    wsClientRoot = this.#ws_client_root

    enableServerDevLog = this.#enable_server_dev_log
    enableClientDevLog = this.#enable_client_dev_log
}

export default new BuildMeta()

