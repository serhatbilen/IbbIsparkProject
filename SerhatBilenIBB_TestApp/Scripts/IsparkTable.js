
    jQuery(function ($) {

        $('#isparkTable').DataTable();

    $("#latitude,#longitude").inputmask({
        mask: "9{1, 3},9{1, 6}",
    min: 0
            });

    $("#working_time").inputmask({
        mask: "99:99 - 99:99"
            });

        });