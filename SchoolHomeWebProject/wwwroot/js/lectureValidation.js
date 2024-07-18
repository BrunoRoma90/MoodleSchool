
function validateDates() {
    var startTime = new Date(document.querySelector('[name="Lecture.StartTime"]').value);
    var endTime = new Date(document.querySelector('[name="Lecture.EndTime"]').value);

    if (endTime < startTime) {
        var errorMessage = document.getElementById('error-message');
        errorMessage.innerText = 'End Time cannot be earlier than Start Time.';
        errorMessage.style.display = 'block';
        return false;
    }

    return true;
}

