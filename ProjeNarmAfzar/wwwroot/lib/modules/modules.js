function readURL(input, priviewImg) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $(priviewImg).attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$("[ImageInput]").change(function () {
    var x = $(this).attr("ImageInput");
    if (this.files && this.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $("[ImageFile=" + x + "]").attr('src', e.target.result);
        };
        reader.readAsDataURL(this.files[0]);
    }
});

function CopyToClipboardByElementId(elementId) {
    var $temp = $("<input>");
    $("body").append($temp);
    var el = $("#" + elementId);
    $temp.val($(el).text()).select();
    document.execCommand("copy");
    $temp.remove();
    ShowMessage('عملیات موفق', 'اطلاعات مورد نظر با موفقیت کپی شد');
}


function CopyToClipboardText(text) {
    var $temp = $("<input>");
    $("body").append($temp);
    $temp.val(text).select();
    document.execCommand("copy");
    $temp.remove();
    ShowMessage('عملیات موفق', 'اطلاعات مورد نظر با موفقیت کپی شد');
}

$(document).ready(function () {

    var doblock = $("[doblock]");
    var IsBlockUI = doblock.length !== 0;
    // block ui when ajax starts
    if (IsBlockUI) {
        $.getScript("/assets/js/CustomJs/jquery.blockUI.js", function (script, textStatus, jqXHR) { });
        $(document).ajaxStart(function () {
            $.blockUI({ message: null });
        });
    }

    // set responsive textarea
    var textAreas = $(".animated");
    if (textAreas.length > 0) {
        $.getScript("/js/ResizeTextArea.js", function (script, textStatus, jqXHR) { });
    }

    // add tags input when we have data-role='tagsinput' attribute
    var tagsInputs = $("[data-role='tagsinput']");
    if (tagsInputs.length > 0) {
        $('<link/>', { rel: 'stylesheet', type: 'text/css', href: '/assets/TagInput/bootstrap-tagsinput.css' })
            .appendTo('head');
        $.getScript("/assets/TagInput/bootstrap-tagsinput.js", function (script, textStatus, jqXHR) { });
    }

    // set ckeditor for textareas where they have ckeditor attribute
    var editors = $("[ckeditor]");
    if (editors.length > 0) {
        $.getScript("/lib/modules/ckeditor/ckeditor.js",
            function (script, textStatus, jqXHR) {
                $(editors).each(function (index, value) {
                    var id = $(value).attr('ckeditor');
                    ClassicEditor.create(document.querySelector('[ckeditor="' + id + '"]'),
                        {
                            toolbar: {
                                items: [
                                    'heading',
                                    '|',
                                    'bold',
                                    'italic',
                                    'link',
                                    '|',
                                    'fontSize',
                                    'fontColor',
                                    '|',
                                    'imageUpload',
                                    'blockQuote',
                                    'insertTable',
                                    'undo',
                                    'redo',
                                    'codeBlock'
                                ]
                            },
                            language: 'fa',
                            table: {
                                contentToolbar: [
                                    'tableColumn',
                                    'tableRow',
                                    'mergeTableCells'
                                ]
                            },
                            licenseKey: '',
                            simpleUpload: {
                                // The URL that the images are uploaded to.
                                uploadUrl: '/Uploader/UploadImage'
                            }

                        }).then(editor => {
                            window.editor = editor;
                        }).catch(error => {
                            console.error(error);
                        });
                });
            });
    }

    // add date picker to inputs that has DatePicker Attribute
    var datePickers = $("[DatePicker]");
    if (datePickers.length > 0) {
        $('<link/>',
            { rel: 'stylesheet', type: 'text/css', href: '/lib/Percian-Calender/style/kamadatepicker.min.css' }).appendTo('head');
        $.getScript("/lib/Percian-Calender/src/kamadatepicker.min.js", function (script, textStatus, jqXHR) { });
    }
});

// fill pageid for pagging
function FillPageId(id) {
    $("#PageId").val(id);
    $("#filter-search").submit();
}



function reloadPageAfterSeconds(seconds) {
    setTimeout(function () {
        location.reload();
    }, seconds);
}

function AddOwlCarousel(selector, config) {
    $(selector).owlCarousel(config);
}


$('[operate-ajax-button]').on('click', function (e) {
    e.preventDefault();
    var url = $(this).attr('href');
    var removeElementId = $(this).attr('operate-ajax-button');
    swal({
        title: 'اخطار',
        text: "آیا از انجام عملیات مورد نظر اطمینان دارید؟",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "بله",
        cancelButtonText: "خیر",
        closeOnConfirm: false,
        closeOnCancel: false
    }).then((result) => {
        if (result.value) {
            open_waiting('body');
            $.get(url).then(res => {
                if (removeElementId !== null && removeElementId !== undefined && removeElementId !== '') {
                    $('[operate-ajax-item="' + removeElementId + '"]').hide(300);
                    close_waiting('body');
                } else {
                    location.reload();
                }
            });
        } else if (result.dismiss === swal.DismissReason.cancel) {
            swal('اعلام', 'عملیات لغو شد', 'error');
        }
    });
});


$('[remove-ajax-button]').on('click', function (e) {
    e.preventDefault();
    var url = $(this).attr('href');
    var removeElementId = $(this).attr('remove-ajax-button');
    swal({
        title: 'اخطار',
        text: "آیا از انجام عملیات مورد نظر اطمینان دارید؟",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "بله",
        cancelButtonText: "خیر",
        closeOnConfirm: false,
        closeOnCancel: false
    }).then((result) => {
        if (result.value) {
            open_waiting('body');
            $.get(url).then(res => {
                if (removeElementId !== null && removeElementId !== undefined && removeElementId !== '') {
                    $('[remove-ajax-item=' + removeElementId + ']').hide(300);
                    close_waiting('body');
                } else {
                    location.reload();
                }
            });
        } else if (result.dismiss === swal.DismissReason.cancel) {
            swal('اعلام', 'عملیات لغو شد', 'error');
        }
    });
});


}