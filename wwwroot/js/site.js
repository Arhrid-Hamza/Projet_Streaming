// Write your JavaScript code.


// Function to confirm delete action
function confirmDelete(message) {
    return confirm(message || 'Are you sure you want to delete this item?');
}

// Attach confirm delete to all delete buttons
$(document).ready(function() {
    $('.btn-delete').on('click', function(e) {
        if (!confirmDelete('Are you sure you want to delete this item?')) {
            e.preventDefault();
        }
    });

    // Form validation for create/edit forms
    $('form').on('submit', function(e) {
        var isValid = true;
        $(this).find('input[required], select[required], textarea[required]').each(function() {
            if ($(this).val().trim() === '') {
                isValid = false;
                $(this).addClass('is-invalid');
            } else {
                $(this).removeClass('is-invalid');
            }
        });
        if (!isValid) {
            e.preventDefault();
            alert('Please fill in all required fields.');
        }
    });

    // AJAX for rating submission (if applicable)
    $('.rating-form').on('submit', function(e) {
        e.preventDefault();
        var form = $(this);
        $.ajax({
            url: form.attr('action'),
            type: 'POST',
            data: form.serialize(),
            success: function(response) {
                alert('Rating submitted successfully!');
                location.reload();
            },
            error: function() {
                alert('Error submitting rating.');
            }
        });
    });
});


// Initialize all functionalities
function initializeAll() {
    initializeCarousels();
    addHoverEffects();
    initializeSmoothScrolling();
    addLoadingAnimations();
    initializeVideoPlayer();
    initializeSearch();
    initializeModals();
    initializeRatings();
    initializeWatchlist();
}

// Re-initialize on dynamic content load
function reinitializeFeatures() {
    initializeCarousels();
    addHoverEffects();
    addLoadingAnimations();
}

// Export functions for global use
window.NetflixDashboard = {
    initializeAll: initializeAll,
    reinitializeFeatures: reinitializeFeatures
};

// Write your JavaScript code.


// Function to confirm delete action
function confirmDelete(message) {
    return confirm(message || 'Are you sure you want to delete this item?');
}

// Attach confirm delete to all delete buttons
$(document).ready(function() {
    $('.btn-delete').on('click', function(e) {
        if (!confirmDelete('Are you sure you want to delete this item?')) {
            e.preventDefault();
        }
    });

    // Form validation for create/edit forms
    $('form').on('submit', function(e) {
        var isValid = true;
        $(this).find('input[required], select[required], textarea[required]').each(function() {
            if ($(this).val().trim() === '') {
                isValid = false;
                $(this).addClass('is-invalid');
            } else {
                $(this).removeClass('is-invalid');
            }
        });
        if (!isValid) {
            e.preventDefault();
            alert('Please fill in all required fields.');
        }
    });

    // AJAX for rating submission (if applicable)
    $('.rating-form').on('submit', function(e) {
        e.preventDefault();
        var form = $(this);
        $.ajax({
            url: form.attr('action'),
            type: 'POST',
            data: form.serialize(),
            success: function(response) {
                alert('Rating submitted successfully!');
                location.reload();
            },
            error: function() {
                alert('Error submitting rating.');
            }
        });
    });
});


// Initialize all functionalities
function initializeAll() {
    initializeCarousels();
    addHoverEffects();
    initializeSmoothScrolling();
    addLoadingAnimations();
    initializeVideoPlayer();
    initializeSearch();
    initializeModals();
    initializeRatings();
    initializeWatchlist();
}

// Re-initialize on dynamic content load
function reinitializeFeatures() {
    initializeCarousels();
    addHoverEffects();
    addLoadingAnimations();
}

// Export functions for global use
window.NetflixDashboard = {
    initializeAll: initializeAll,
    reinitializeFeatures: reinitializeFeatures
};

