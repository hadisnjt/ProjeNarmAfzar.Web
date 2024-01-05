function FillPageId(page) {
    $('#Page').val(page);
    $('#filter-form').submit();
}


function RemoveVideo(videoId) {
    $.get('/Admin/Video/RemoveVideo/' + videoId).then(result => {
        if (result.status === 'success') {
            $('#video-row-' + videoId).fadeOut();
            location.reload();
        }
    });


}function ReturnVideo(videoId) {
    $.get('/Admin/Video/ReturnVideo/' + videoId).then(result => {
        if (result.status === 'success') {
            $('#video-row-' + videoId).fadeOut();
            location.reload();
        }
    });
}
