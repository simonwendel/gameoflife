// <copyright file="gameoflife.js" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

(function ($) {
    $(function () {
        $('#dialog').dialog({
            modal: true,
            title: 'Game Of Life',
            closeOnEscape: false,
            dialogClass: 'no-close',
            buttons: [{
                text: 'Run game',
                click: function () {
                    var options = $('#options :input').serialize();
                    runGame(options, '#output');
                }
            }]
        });
    });

    function runGame(options, outputSelector) {
        $.post(
            'Home/RunGame',
            options,
            function (data, textStatus, jqXHR) {
                var output = $(outputSelector).empty();
                output.append(data);
            });
    }
})(jQuery);

// eof