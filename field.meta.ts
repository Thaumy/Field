const cdn_root = 'https://cdn.thaumy.cn/field_next'

class BuildMeta {
    //config Field here
    #site_title = 'THAUMY的小站'
    #site_icon_url = `${cdn_root}/ui_img/icon.png`
    #enable_cdn = true
    #cdn_url = cdn_root

    #avatar_img_url = `${cdn_root}/ui_img/avatar.png`
    #background_img_url = `${cdn_root}/ui_img/background.jpg`

    #ws_server_root = 'ws://127.0.0.1:40020'
    #ws_client_root = 'ws://127.0.0.1:40030'
    //#ws_client_root = 'wss://next.thaumy.cn:40030'

    #ws_max_concurrent = 5
    #ws_retry_interval = 50

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
    wsClientMaxConcurrent = this.#ws_max_concurrent
    wsClientRetryInterval = this.#ws_retry_interval

    enableServerDevLog = this.#enable_server_dev_log
    enableClientDevLog = this.#enable_client_dev_log
}

export default new BuildMeta()

