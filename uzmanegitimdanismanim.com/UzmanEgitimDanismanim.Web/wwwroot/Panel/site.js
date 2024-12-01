var MesajSuccessSagUst = function(metin) {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer);
            toast.addEventListener('mouseleave', Swal.resumeTimer);
        }
    });

    Toast.fire({
        icon: 'success',
        title: metin
    });
};
var MesajErrorSagUst = function(metin) {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer);
            toast.addEventListener('mouseleave', Swal.resumeTimer);
        }
    });

    Toast.fire({
        icon: 'error',
        title: metin
    });
};

var MesajWarrningSagUst = function (metin) {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer);
            toast.addEventListener('mouseleave', Swal.resumeTimer);
        }
    });

    Toast.fire({
        icon: 'warrning',
        title: metin
    });
};

var MesajInfoSagUst = function (metin) {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer);
            toast.addEventListener('mouseleave', Swal.resumeTimer);
        }
    });

    Toast.fire({
        icon: 'info',
        title: metin
    });
};

var MesajConfirm = function (metin, icon, url, returnUrl) {
    Swal.fire({
        title: metin,
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: 'Evet',
        denyButtonText: 'İptal',
        icon: icon,
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: url,
                success: function (response) {
                    Swal.fire({
                        title: 'İşleminiz başarılı bir şekilde gerçekleşti.!',
                        icon: 'success',
                    }).then((result) => {
                        if (result.isConfirmed) {
                            window.location.href = returnUrl;
                        }
                    });
                }
            });
        }
    });
};

var MesajVer = function(baslik, mesaj, icon) {
    Swal.fire(
        baslik,
        mesaj,
        icon
    );
};




$("#SinifDersId").change(function () {
    $('#SinifDersKonuId').html("");
    var sinifDersId = $("#SinifDersId").val();
    if (parseInt(sinifDersId)) {
        $.ajax({
            type: "GET",
            url: "/DanismanPanel/KonuTakip/SinifDersKonuGetir",
            data: {
                "sinifDersId": sinifDersId,
            },
            async: false,
            success: function (e) {
                var jsonObj = e;
    
                $.each(jsonObj, function () {
                    $('#SinifDersKonuId')
                        .append($("<option></option>")
                            .attr("value", $(this).attr("id"))
                            .text($(this).attr("sinifDersKonuAdi")));
                });
            },
            error: function (err) { }
        });
    }
});

$("#Ilceler").change(function () {
    $('#MebOkullar').html("");
    $('#BTNEKLE').css('display', 'none');
    var il_kod = $("#Iller").val();
    var ilce_kod = $("#Ilceler").val();
    if (parseInt(il_kod) & parseInt(ilce_kod)) {
        $.ajax({
            type: "GET",
            url: "MebOkulGetir",
            data: {
                "il_kod": il_kod,
                "ilce_kod": ilce_kod
            },
            async: false,
            success: function (e) {
                var jsonObj = e;
                $('#MebOkullar')
                    .append($("<option></option>")
                        .attr("value", "0")
                        .text("-- Seçiniz --"));

                $.each(jsonObj, function () {
                    $('#MebOkullar')
                        .append($("<option></option>")
                            .attr("value", $(this).attr("okul_Id"))
                            .text($(this).attr("okul_Adi")));
                });
            },
            error: function (err) { }
        });
    }
});



//Kullanici Beyan Adres Ekleme sayfasında kullanılıyor

$("#Il_Kod").change(function () {
    $('#Ilce_Kod').html("");
    $('#Mahalle_Kod').html("");
    var il_kod = $("#Il_Kod").val();
    if (parseInt(il_kod)) {
        $.ajax({
            type: "GET",
            url: "/Main/Admin/IlceGetir",
            data: {
                "il_kod": il_kod,
            },
            async: false,
            success: function (e) {
                var jsonObj = e;
                $('#Ilce_Kod')
                    .append($("<option></option>")
                        .attr("value", "0")
                        .text("-- Seçiniz --"));

                $.each(jsonObj, function () {
                    $('#Ilce_Kod')
                        .append($("<option></option>")
                            .attr("value", $(this).attr("ilce_Kod"))
                            .text($(this).attr("ilce_Adi")));
                });
            },
            error: function (err) {
            }
        });
    }
});

$("#Ilce_Kod").change(function () {
    $('#Mahalle_Kod').html("");
    var ilce_kod = $("#Ilce_Kod").val();
    if (parseInt(ilce_kod)) {
        $.ajax({
            type: "GET",
            url: "/Main/Admin/MahalleGetir",
            data: {
                "ilce_kod": ilce_kod,
            },
            async: false,
            success: function (e) {
                var jsonObj = e;
                $('#Mahalle_Kod')
                    .append($("<option></option>")
                        .attr("value", "0")
                        .text("-- Seçiniz --"));

                $.each(jsonObj, function () {
                    $('#Mahalle_Kod')
                        .append($("<option></option>")
                            .attr("value", $(this).attr("mahalle_Kod"))
                            .text($(this).attr("mahalle_Adi")));
                });
            },
            error: function (err) { }
        });
    }
});


$("#KategoriId").change(function () {
    window.location.href = "IcerikListele?id=" + $("#KategoriId").val();
});


var ReklamAta = function (KullaniciId, ReklamId) {
    alert(KullaniciId + ' ' + ReklamId);

    //if (result.isConfirmed) {
    //    $.ajax({
    //        type: "POST",
    //        url: url,
    //        success: function (response) {
    //            Swal.fire({
    //                title: 'İşleminiz başarılı bir şekilde gerçekleşti.!',
    //                icon: 'success',
    //            }).then((result) => {
    //                if (result.isConfirmed) {
    //                    window.location.href = returnUrl;
    //                }
    //            });
    //        }
    //    });
    //}

};