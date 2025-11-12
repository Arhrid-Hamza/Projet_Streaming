// Netflix-like Dashboard JavaScript

document.addEventListener('DOMContentLoaded', function() {
    // Initialize carousels
    initializeCarousels();

    // Add hover effects
    addHoverEffects();

    // Initialize smooth scrolling
    initializeSmoothScrolling();

    // Add loading animations
    addLoadingAnimations();
});

function initializeCarousels() {
    const carousels = document.querySelectorAll('.content-carousel');

    carousels.forEach(carousel => {
        let isDown = false;
        let startX;
        let scrollLeft;

        carousel.addEventListener('mousedown', (e) => {
            isDown = true;
            carousel.classList.add('active');
            startX = e.pageX - carousel.offsetLeft;
            scrollLeft = carousel.scrollLeft;
        });

        carousel.addEventListener('mouseleave', () => {
            isDown = false;
            carousel.classList.remove('active');
        });

        carousel.addEventListener('mouseup', () => {
            isDown = false;
            carousel.classList.remove('active');
        });

        carousel.addEventListener('mousemove', (e) => {
            if (!isDown) return;
            e.preventDefault();
            const x = e.pageX - carousel.offsetLeft;
            const walk = (x - startX) * 2;
            carousel.scrollLeft = scrollLeft - walk;
        });
    });
}

function addHoverEffects() {
    const contentItems = document.querySelectorAll('.content-item');

    contentItems.forEach(item => {
        item.addEventListener('mouseenter', function() {
            this.style.transform = 'scale(1.05)';
        });

        item.addEventListener('mouseleave', function() {
            this.style.transform = 'scale(1)';
        });
    });
}

function initializeSmoothScrolling() {
    const links = document.querySelectorAll('a[href^="#"]');

    links.forEach(link => {
        link.addEventListener('click', function(e) {
            e.preventDefault();

            const targetId = this.getAttribute('href').substring(1);
            const targetElement = document.getElementById(targetId);

            if (targetElement) {
                targetElement.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });
}

function addLoadingAnimations() {
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('fade-in-up');
            }
        });
    }, observerOptions);

    const elementsToAnimate = document.querySelectorAll('.content-section, .category-card, .cta-section');
    elementsToAnimate.forEach(element => {
        observer.observe(element);
    });
}

// Video player functionality
function initializeVideoPlayer() {
    const videoElements = document.querySelectorAll('.video-player');

    videoElements.forEach(video => {
        video.addEventListener('loadeddata', function() {
            console.log('Video loaded successfully');
        });

        video.addEventListener('error', function() {
            console.error('Error loading video');
        });
    });
}

// Search functionality
function initializeSearch() {
    const searchInput = document.getElementById('searchInput');

    if (searchInput) {
        searchInput.addEventListener('input', function() {
            const query = this.value.toLowerCase();
            const contentItems = document.querySelectorAll('.content-item');

            contentItems.forEach(item => {
                const title = item.querySelector('h5')?.textContent.toLowerCase() || '';
                const description = item.querySelector('p')?.textContent.toLowerCase() || '';

                if (title.includes(query) || description.includes(query)) {
                    item.style.display = 'block';
                } else {
                    item.style.display = 'none';
                }
            });
        });
    }
}

// Modal functionality for content details
function initializeModals() {
    const modalTriggers = document.querySelectorAll('[data-toggle="modal"]');

    modalTriggers.forEach(trigger => {
        trigger.addEventListener('click', function(e) {
            e.preventDefault();
            const modalId = this.getAttribute('data-target');
            const modal = document.querySelector(modalId);

            if (modal) {
                modal.style.display = 'block';
                document.body.style.overflow = 'hidden';
            }
        });
    });

    // Close modals
    const closeButtons = document.querySelectorAll('.modal .close, .modal');

    closeButtons.forEach(button => {
        button.addEventListener('click', function() {
            const modal = this.closest('.modal');
            if (modal) {
                modal.style.display = 'none';
                document.body.style.overflow = 'auto';
            }
        });
    });
}

// Rating functionality
function initializeRatings() {
    const ratingElements = document.querySelectorAll('.rating');

    ratingElements.forEach(rating => {
        const stars = rating.querySelectorAll('.star');

        stars.forEach((star, index) => {
            star.addEventListener('click', function() {
                const ratingValue = index + 1;

                stars.forEach((s, i) => {
                    if (i < ratingValue) {
                        s.classList.add('active');
                    } else {
                        s.classList.remove('active');
                    }
                });

                // Send rating to server
                console.log('Rating submitted:', ratingValue);
            });
        });
    });
}

// Watchlist functionality
function initializeWatchlist() {
    const watchlistButtons = document.querySelectorAll('.watchlist-btn');

    watchlistButtons.forEach(button => {
        button.addEventListener('click', function() {
            const contentId = this.getAttribute('data-content-id');
            const isInWatchlist = this.classList.contains('active');

            if (isInWatchlist) {
                // Remove from watchlist
                this.classList.remove('active');
                this.innerHTML = '<i class="fas fa-plus"></i> Add to Watchlist';
            } else {
                // Add to watchlist
                this.classList.add('active');
                this.innerHTML = '<i class="fas fa-check"></i> In Watchlist';
            }

            // Send request to server
            console.log('Watchlist updated for content:', contentId);
        });
    });
}

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

// Write your JavaScript code.
