
    jQuery(function ($) {

        $('#EkleModelPopUp').on('hidden.bs.modal', function (e) {
            $('#EkleModelPopUp').find("input").val('');
        })

            $(document).on('click', '#isparkKayit', function (e) {
        e.preventDefault();

    var $form = $('#isparkKayitForm');

    //if (!$form.validate().form()) return false;

    var GonderilecekData = { };

    var arr = $form.serializeArray();

    for (var i = 0; i < arr.length; i++) {
        GonderilecekData[arr[i].name] = arr[i].value;
                }

    $.ajax({
        type: $form.attr('method'),
    url: $form.attr('action'),
    contentType: 'application/json',
    dataType: 'json', // data type
    data: JSON.stringify(GonderilecekData),
    success: function (s) {
                        if (s.status) {
        window.location = window.location;
                        }
                    },
    error: function (e) {
        console.log(e);
                    }
                });
            });

    $(document).on('click', '[data-ispark-uid]', function (e) {
        e.preventDefault();

    var nesne = $(this);

    $.ajax({
        type: 'POST',
    url: '@Url.Action("JsonDetay", "Ispark", null)',
    data: JSON.stringify({uid: nesne.attr('data-ispark-uid') }),
    contentType: 'application/json',
    success: function (s) {
        $.each(s, function (i, v) {
            $('#isparkKayitForm').find('[name="' + i + '"]').val(v);
            $('#EkleModelPopUp').modal('show');
        });
                    },
    error: function (e) { }
                })

            });

        });