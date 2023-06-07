

    jQuery(function ($) {

        function OtoparkSil(otoparkId, otoparkAd) {
            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-success',
                    cancelButton: 'btn btn-danger'
                },
                buttonsStyling: false
            })

            swalWithBootstrapButtons.fire({
                title: 'Otopark Silinecek!',
                text: otoparkAd + " isimli otoparkı silmek istediğinize emin misiniz?",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Evet',
                cancelButtonText: 'Hayır',
                reverseButtons: true
            }).then((result) => {
                if (result.isConfirmed) {

                    $.ajax({
                        type: 'POST',
                        url: '@Url.Action("Sil", "Ispark", null)',
                        data: JSON.stringify({ uid: otoparkId }),
                        contentType: 'application/json',
                        success: function (s) {
                            if (s.status) {
                                swalWithBootstrapButtons.fire(
                                    'Silindi',
                                    otoparkAd + ' Otoparkı Silindi!',
                                    'success'
                                ).then((result) => {
                                    window.location = window.location;
                                });
                            }
                            else {
                                swalWithBootstrapButtons.fire(
                                    'HATA!',
                                    otoparkAd + ' Otoparkı Silinemedi!',
                                    'error'
                                )
                            }
                        },
                        error: function (e) { }
                    });

                } else if (
                    result.dismiss === Swal.DismissReason.cancel
                ) {
                    swalWithBootstrapButtons.fire(
                        'Silme işlemi iptal edildi',
                        otoparkAd + ' Otoparkı SİLİNMEDİ!',
                        'error'
                    )
                }
            })
        }

            $(document).on('click', '[data-ispark-sil-uid]', function (e) {
        e.preventDefault();

    var nesne = $(this);

    OtoparkSil(nesne.attr('data-ispark-sil-uid'), nesne.attr('data-ispark-adi'));

            });

        });