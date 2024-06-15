$(document).ready(function () {
    GetProvince();

    var provinceId = '@Model.Province';
    var districtId = '@Model.District';
    var municipalityId = '@Model.Municipality';

    if (provinceId) {
        $('#District').prop('disabled', false);
        $('#District').empty().append('<option value="">--Select District--</option>');
        $.ajax({
            url: '/Customer/District?id=' + provinceId,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#District').append('<option value="' + data.districtId + '">' + data.districtName + '</option>');
                });
                $('#District').val(districtId);
                if (!$('#District').val()) {
                    $('#District').val(''); 
                }
            }
        });
    }

    if (districtId) {
        $('#Municipality').prop('disabled', false);
        $('#Municipality').empty().append('<option value="">--Select Municipality--</option>');
        $.ajax({
            url: '/Customer/Municipality?id=' + districtId,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#Municipality').append('<option value="' + data.munId + '">' + data.munName + '</option>');
                });
                $('#Municipality').val(municipalityId);
                if (!$('#Municipality').val()) {
                    $('#Municipality').val(''); 
                }
            }
        });
    }

    $('#Province').change(function () {
        var provinceId = $(this).val();
        if (provinceId) {
            $('#District').prop('disabled', false);
            $('#District').empty().append('<option value="">--Select District--</option>');
            $.ajax({
                url: '/Customer/District?id=' + provinceId,
                success: function (result) {
                    $.each(result, function (i, data) {
                        $('#District').append('<option value="' + data.districtId + '">' + data.districtName + '</option>');
                    });
                }
            });
        } else {
            $('#District').prop('disabled', true).empty().append('<option value="">--Select District--</option>');
            $('#Municipality').prop('disabled', true).empty().append('<option value="">--Select Municipality--</option>');
        }
    });

    $('#District').change(function () {
        var districtId = $(this).val();
        if (districtId) {
            $('#Municipality').prop('disabled', false);
            $('#Municipality').empty().append('<option value="">--Select Municipality--</option>');
            $.ajax({
                url: '/Customer/Municipality?id=' + districtId,
                success: function (result) {
                    $.each(result, function (i, data) {
                        $('#Municipality').append('<option value="' + data.munId + '">' + data.munName + '</option>');
                    });
                }
            });
        } else {
            $('#Municipality').prop('disabled', true).empty().append('<option value="">--Select Municipality--</option>');
        }
    });
});

function GetProvince() {
    $.ajax({
        url: '/Customer/Province',
        success: function (result) {
            var provinceSelect = $('#Province');
            provinceSelect.empty().append('<option value="">--Select Province--</option>');
            $.each(result, function (i, data) {
                provinceSelect.append('<option value="' + data.provinceId + '">' + data.provinceName + '</option>');
            });
            provinceSelect.val('@Model.Province');
            if (!provinceSelect.val()) {
                provinceSelect.val(''); // 
            }
        }
    });
}
