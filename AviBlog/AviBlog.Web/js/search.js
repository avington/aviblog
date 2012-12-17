/// <reference path="../Scripts/jquery-1.8.0-vsdoc.js" />

/// <reference path="../Scripts/jquery-1.8.0.js" />


var searchSite = (function($) {

    var init = function() {
        var $button = $('#search-button'),
            $query = $('#q'),
            $form = $('#search-panel form');

        $button.on('click', function() {
            if ($query.val() !== '') {
                $form.submit();
            }
        });
    };

    return { init: init };
})(jQuery);

jQuery(document).ready(function() {
    searchSite.init();
});