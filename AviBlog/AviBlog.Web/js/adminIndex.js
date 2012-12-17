/// <reference path="../Scripts/jquery-ui-1.8.23.min.js" />
/// <reference path="../Scripts/jquery-1.8.0.js" />
/// <reference path="../Scripts/jquery-1.8.0-vsdoc.js" />
/// <reference path="../Scripts/jquery.validate-vsdoc.js" />
/// <reference path="../Scripts/jquery.validate.js" />

var indexAdmin = function ($) {

    var $waitPanel = $('#index-waiting-panel'),
        $reindex = $('#reindex'),
        $status = $('#reindex-status-panel ul'),
        postUrl = '/manage/index/reindex',
        displayIndexCompletionStatus = function (items) {
            console.log('data returned', items);
            $waitPanel.css({ display: 'none' });
            $.each(items, function () {
                $status.append('<li>' + this + '</li>');
            });
        },
        init = function () {

            $reindex.on('click', function () {
                $waitPanel.css({ display: 'inline' });
                $.ajax({
                    url: postUrl,
                    cache: false,
                    contentType: 'application/json; charset=utf-8',
                    dataType: "json",
                    type: "POST",
                    success: function (data) {
                        displayIndexCompletionStatus(data);
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        console.log(jqXHR);
                        console.log(textStatus);
                        console.log(errorThrown);
                        displayIndexCompletionStatus(errorThrown);
                    }
                });
            });
        };


    return { init: init };

}(jQuery);

jQuery(document).ready(function() {
    indexAdmin.init();
});