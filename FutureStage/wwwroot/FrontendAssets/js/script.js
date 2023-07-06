////$(document).ready(function () {
////    var sliderwrapper = $('.slider-wrapper');
////    var slideritems = $('.slider-item');
////    var slidewidth = slideritems.first().outerwidth();
////    var currentindex = 0;

////    function clonecards() {
////        var cloneditems = slideritems.clone();
////        sliderwrapper.append(cloneditems);
////    }

////    function slidetocurrent() {
////        var translatex = -currentindex * slidewidth;
////        sliderwrapper.css('transition', 'transform 0.6s ease');
////        sliderwrapper.css('transform', 'translatex(' + translatex + 'px)');
////    }

////    function nextslide() {
////        currentindex++;
////        slidetocurrent();
////    }

////    function prevslide() {
////        currentindex--;
////        slidetocurrent();
////    }

////    function startautoslide() {
////        setinterval(function () {
////            clonecards();
////            nextslide();
////        }, 3000);
////    }

////    $('.slider-next-btn').click(function () {
////        clonecards();
////        nextslide();
////    });

////    $('.slider-prev-btn').click(function () {
////        clonecards();
////        prevslide();
////    });

////    startAutoSlide();
////});
$(document).ready(function () {
    var sliderWrapper = $('.slider-wrapper');
    var sliderItems = $('.slider-item');
    var slideWidth = sliderItems.first().outerWidth();
    var totalItems = sliderItems.length;
    var currentIndex = 0;

    function slideToCurrent() {
        var translateX = -currentIndex * slideWidth;
        sliderWrapper.css('transition', 'transform 0.6s ease');
        sliderWrapper.css('transform', 'translateX(' + translateX + 'px)');
    }

    function nextSlide() {
        currentIndex++;
        if (currentIndex >= totalItems) {
            currentIndex = 0;
            sliderWrapper.css('transition', 'none');
            sliderWrapper.css('transform', 'translateX(0)');
            setTimeout(function () {
                sliderWrapper.css('transition', 'transform 0.6s ease');
                slideToCurrent();
            }, 10);
        } else {
            slideToCurrent();
        }
    }

    function prevSlide() {
        currentIndex--;
        if (currentIndex < 0) {
            currentIndex = totalItems - 1;
            sliderWrapper.css('transition', 'none');
            sliderWrapper.css('transform', 'translateX(' + (-slideWidth * totalItems) + 'px)');
            setTimeout(function () {
                sliderWrapper.css('transition', 'transform 0.6s ease');
                slideToCurrent();
            }, 10);
        } else {
            slideToCurrent();
        }
    }

    function startAutoSlide() {
        setInterval(function () {
            nextSlide();
        }, 3000);
    }

    $('.slider-next-btn').click(function () {
        nextSlide();
    });

    $('.slider-prev-btn').click(function () {
        prevSlide();
    });

    startAutoSlide();
});



