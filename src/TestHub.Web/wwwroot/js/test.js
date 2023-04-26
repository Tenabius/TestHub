// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
(function countdown() {
    var minutes = parseInt($(".countdown-hook").attr("duration-minutes"));
    var timer = new easytimer.Timer();
    timer.start({
        startValues: {
            minutes: minutes
        },
        countdown: true
    });
    let isRunningOut = false;
    timer.addEventListener('secondsUpdated', function (e) {
        let time = timer.getTimeValues();
        $('.countdown-hook').html(time.toString());
        if (time.minutes < 1 && !isRunningOut) {
            $('.countdown-hook').addClass("countdown-warning");
        }
    });
    timer.addEventListener('stopped', () => $("#Submit")[0].click());
})();

$(function matchingQuestion() {
    function handleRevert(dropped) {
        if (!dropped) {
            $(this).data("uiDraggable").originalPosition = {
                top: 0,
                left: 0
            };
            $(this).off("dragstart");
        }
        return !dropped;
    }

    function handleOutEvent(event, ui) {
        var $self = $(this);
        $self.children("input[name*='SubmittedResponse']").val("");
    }

    function handleDropEvent(event, ui) {
        var $self = $(this);
        var $item = ui.draggable;
        $item.position({
            my: 'left top',
            at: 'left top',
            of: $self
        });
        $self.children("input[name*='SubmittedResponse']")
            .val($item.children("div[name='SubmittedResponseId']").attr("value"));
        $self.droppable("destroy");
        $item.on("dragstart", () => createDroppable($self.get()));
    }

    function createDraggable(item) {
        $(item).draggable({
            containment: $(".containment"),
            revert: handleRevert,
            stack: $(".draggable"),
            cursor: "grabbing",
            revertDuration: 100
        });
    }

    $(".draggable").each((index, item) => createDraggable(item));

    function createDroppable(item) {
        $(item).droppable({
            drop: handleDropEvent,
            tolerance: "pointer",
            out: handleOutEvent
        });
    }

    $(".droppable").each((index, item) => createDroppable(item));
});

$(function fillBlankQuestion() {
    document.querySelectorAll("input.dynamic-lenght-input").forEach((element) => {
        element.addEventListener('input', () => {
            element
                .parentElement
                .querySelector("span.dynamic-lenght-input-span")
                .innerText = element.value;
        })
    })
});