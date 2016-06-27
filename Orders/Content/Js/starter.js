$(document).ready(function () {

    $('.tag-select').append('<option value="" selected="selected">Choose...<option>');
    $('.tag-select').trigger("chosen:updated");


    function disableBack() {
        window.history.forward()
    }

    window.onload = disableBack();
    window.onpageshow = function (evt) {
        if (evt.persisted)
            disableBack()
    }

    $('[data-toggle="tooltip"]').tooltip();

    /*
     * Custom Select
     */
    $('.tag-select2').selectpicker({
        liveSearch: true
    });

    $('input[type="date"]').datetimepicker({
        'format': 'YYYY-MM-DD',
        locale: 'es',
        icons: {
            previous: 'fa fa-chevron-left',
            next: 'fa fa-chevron-right'
        }
    });

    $('input[name^="gema_gemabundle_activo[estOps]"]').datetimepicker({
        'format': false,
        locale: 'es',
        sideBySide: true,
        icons: {
            previous: 'fa fa-chevron-left',
            next: 'fa fa-chevron-right',

            time: 'glyphicon glyphicon-time',
            date: 'glyphicon glyphicon-calendar',
            up: 'fa fa-chevron-up',
            down: 'fa fa-chevron-down',
            today: 'glyphicon glyphicon-screenshot',
            clear: 'glyphicon glyphicon-trash',
            close: 'glyphicon glyphicon-remove'
        }
    });

    /*
     * Tag Select
     */
    $('.tag-select').chosen({
        disable_search: false,
        no_results_text: "No hay coincidencias",
        placeholder_text_multiple: "Por favor, seleccione...",
        placeholder_text_single: "Por favor, seleccione...",
        width: '150%',
        allow_single_deselect: true,
        search_contains: true
    });

    /*
     * Date Time Picker
     */

    //Date Time Picker
    if ($('.date-time-picker')[0]) {
        $('.date-time-picker').datetimepicker();
    }

    //Time
    if ($('.time-picker')[0]) {
        $('.time-picker').datetimepicker({
            format: 'LT'
        });
    }

    //Date
    if ($('.date-picker')[0]) {
        $('.date-picker').datetimepicker({
            format: 'DD/MM/YYYY'
        });
    }
    /*
     * Custom Scrollbars
     */
    function scrollbar(className, color, cursorWidth) {
        $(className).niceScroll({
            cursorcolor: color,
            cursorborder: 0,
            cursorborderradius: 0,
            cursorwidth: cursorWidth,
            bouncescroll: true,
            mousescrollstep: 100
        });
    }

    //Scrollbar for HTML(not mobile) but not for login page
    if ($('html')) {
        if (!$('.login_gema')[0]) {
            scrollbar('html', 'rgba(0,0,0,0.3)', '5px');
        }

        //Scrollbar Tables
        if ($('.table-responsive')[0]) {
            scrollbar('.table-responsive', 'rgba(0,0,0,0.5)', '5px');
        }

        //Scrill bar for Chosen
        if ($('.chosen-results')[0]) {
            scrollbar('.chosen-results', 'rgba(0,0,0,0.5)', '5px');
        }

        //Scrollbar for rest
        if ($('.c-overflow')[0]) {
            scrollbar('.c-overflow', 'rgba(0,0,0,0.5)', '5px');
        }
    }







});
