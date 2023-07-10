var style = "header {display: none !important;}";
style += " footer {display: none !important;}";
style += " .header-wrap{display: none !important;}"     //hide div (https://fanagoriatravel.com/)

function addNewStyle() {
    var styleElement = document.createElement('style');
    styleElement.type = 'text/css';
    styleElement.id = 'styles_js';
    styleElement.appendChild(document.createTextNode(style));

    document.getElementsByTagName('head')[0].appendChild(styleElement);

}
addNewStyle()