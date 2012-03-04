/// <reference path="../Scripts/jquery-1.7.1.min.js" />
/// <reference path="../Scripts/jquery-ui-1.8.17.min.js" />
/// <reference path="../Scripts/jquery-1.7.1-vsdoc.js" />
/// <reference path="../Scripts/jquery.validate-vsdoc.js" />
/// <reference path="../Scripts/jquery.validate.js" />


var pingServiceModel = (function ($, ajaxUrl, indexUrl) {
    var $createButton = $('#create-ping-url-link');
    var $editLinks = $(".ping-edit-link");
    var $dialogBox = $('#ping-service-edit-dialog');
    var $form = $('#ping-service-edit-dialog').find('form');
    var $error = $('#ping-service-error');

    var init = function () {
        $(document).ready(function () {
            $dialogBox.dialog(
                {
                    model: true,
                    autoOpen: false,
                    closeOnEscape: true
                });
        });

    };
    var createClicked = function () {
        $(document).ready(function () {
            $createButton.on("click", null, function () {
                $dialogBox.dialog("open");
            });
        });
    };

    var editClicked = function () {
        $(document).ready(function () {
            $editLinks.on('click', null, function () {
                var $parent = $(this).parent();
                console.log('parent is ', $parent);
            });
        });
    };

    var submitPingServiceUrl = function () {
        $(document).ready(function () {
            $form.on('submit', null, function () {
                var pingId = $('#ping-service-id').val();
                var pingUrl = $('#PingUrl').val();
                var inputData = { pingId: pingId, pingUrl: pingUrl };
                $.getJSON(ajaxUrl, inputData, function (data) {
                    parseResponse(data);
                });
                return false;
            });
        });
    };

    var parseResponse = function (data) {
        if (data.Status) {
            $dialogBox.dialog('close');
            window.location = indexUrl;
        }
        $error.val(data.ErrorMessage).css({ display: 'inline' });

    };

    return {
        init: init,
        createClicked: createClicked,
        editClicked: editClicked,
        submitPingServiceUrl: submitPingServiceUrl
    };
})(jQuery, pingAddUpdateUrl, pingIndexUrl);

 pingServiceModel.init();
 pingServiceModel.createClicked();
 pingServiceModel.submitPingServiceUrl();
