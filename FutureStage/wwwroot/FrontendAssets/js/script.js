
$(document).ready(function () {
    var sliderWrapper = $('.slider-wrapper');
    var sliderItems = $('.slider-item');
    var totalItems = sliderItems.length;
    var slideInterval;
    var currentIndex = 0;
    var slideWidth = sliderItems.first().outerWidth();

  
    var clonedItems = sliderItems.clone();
    sliderWrapper.append(clonedItems);

    $('.next-btn').click(function () {
        nextSlide();
    });

    $('.prev-btn').click(function () {
        prevSlide();
    });

    function nextSlide() {
        currentIndex++;
        slideToCurrent();
    }

    function prevSlide() {
        currentIndex--;
        slideToCurrent();
    }

    function slideToCurrent() {
        var translateX = -currentIndex * slideWidth;
        sliderWrapper.css('transform', 'translateX(' + translateX + 'px)');

        if (currentIndex === totalItems * 2) {
            currentIndex = 0;
            setTimeout(function () {
                sliderWrapper.css('transition', 'none');
                sliderWrapper.css('transform', 'translateX(0)');
                setTimeout(function () {
                    sliderWrapper.css('transition', '');
                }, 10);
            }, 600);
        } else if (currentIndex < 0) {
            currentIndex = totalItems * 2 - 1;
            setTimeout(function () {
                var translateX = -currentIndex * slideWidth;
                sliderWrapper.css('transition', 'none');
                sliderWrapper.css('transform', 'translateX(' + translateX + 'px)');
                setTimeout(function () {
                    sliderWrapper.css('transition', '');
                }, 10);
            }, 600);
        }
    }

    function startAutoSlide() {
        slideInterval = setInterval(nextSlide, 3000);
    }

    function stopAutoSlide() {
        clearInterval(slideInterval);
    }

    sliderWrapper.hover(function () {
        stopAutoSlide();
    }, function () {
        startAutoSlide();
    });

    startAutoSlide();
});

