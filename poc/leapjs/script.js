var output = document.getElementById('output');
var actionOutput = document.getElementById('actionOutput');
var leftHandOutput = document.getElementById('left-hand-output');
var rightHandOutput = document.getElementById('right-hand-output');
var leftHand = document.getElementById('left-hand');
var rightHand = document.getElementById('right-hand');
var gestureOutput = document.getElementById('output-gesture');
var frameString = "",
		handString = "",
		fingerString = "",
		rightHandString = "",
		leftHandString = "";
var hand, finger;

function rad2deg(radians) {
		return radians * (180 / 3.1456)
}

function concatData(id, data) {
		return id + ": " + data + "<br>";
}

function trunk(number, digits) {
		var multiplier = Math.pow(10, digits),
				adjustedNum = number * multiplier,
				truncatedNum = Math[adjustedNum < 0 ? 'ceil' : 'floor'](adjustedNum);

		return truncatedNum / multiplier;
};

function getFingerName(fingerType) {
		switch (fingerType) {
				case 0:
						return 'Thumb';
						break;

				case 1:
						return 'Index';
						break;

				case 2:
						return 'Middle';
						break;

				case 3:
						return 'Ring';
						break;

				case 4:
						return 'Pinky';
						break;
		}
}

function concatJointPosition(id, position) {
		return id + ": " + position[0] + ", " + position[1] + ", " + position[2] + "<br>";
}

function customGestures(hand) {

		//detect hand forward (attack / defense)
		if (hand.palmPosition[2] <= -50 && hand.palmVelocity[2] <= -500) {
				if (hand.type == "right")
						actionOutput.innerHTML = "[" + new Date().getTime() + "] Attaque";
				else

						actionOutput.innerHTML = "[" + new Date().getTime() + "] Défense";
		} else if ((hand.palmVelocity[2] <= 150) && (hand.type == "right"))
		//detect mage attack
		{
			actionOutput.innerHTML = "mage";
			if (hand.grab_strength == 1)
				actionOutput.innerHTML = "[" + new Date().getTime() + "] Chargement feu";
			else if (hand.grab_strength == 0)
				actionOutput.innerHTML = "[" + new Date().getTime() + "] Attaque feu";
				
		} 

}

// Leap.loop uses browser's requestAnimationFrame
var options = {}; //{ enableGestures: true };

// Main Leap Loop
var controller = Leap.loop(options, function(frame) {
		frameString = concatData("frame_id", frame.id);
		frameString += concatData("num_hands", frame.hands.length);
		frameString += concatData("num_fingers", frame.fingers.length);
		frameString += "<br>";

		for (var i = 0, len = frame.hands.length; i < len; i++) {
				hand = frame.hands[i];

				handString = concatData("hand_id", hand.id);
				handString += concatData("hand_type", hand.type);
				handString += concatData("grab_strength", trunk(hand.grabStrength, 1));
				handString += concatData("hand_roll", trunk(rad2deg(hand.roll()), 1));
				handString += concatData("palm_position", trunk(hand.palmPosition[2], 1));
				handString += concatData("palm_velocity", trunk(hand.palmVelocity[2], 1));
				handString += '<br>';

				customGestures(hand);

				if (hand.type == "right") {
						rightHandString = handString;
						rightHand.style.left = (300 + hand.palmPosition[0]) + "px";
						rightHand.style.top = (300 - hand.palmPosition[1]) + "px";
				} else {
						leftHandString = handString;
						leftHand.style.left = (300 + hand.palmPosition[0]) + "px";
						leftHand.style.top = (300 - hand.palmPosition[1]) + "px";
				}

				leftHandOutput.innerHTML = leftHandString;
				rightHandOutput.innerHTML = rightHandString;
		}

		output.innerHTML = frameString;

});

controller.on("gesture", function(gesture) {
		/*gestureOutput.innerHTML = gesture;
		switch (gesture.type) {
				case "circle":
						console.log("Circle Gesture");
						break;
				case "keyTap":
						console.log("Key Tap Gesture");
						break;
				case "screenTap":
						console.log("Screen Tap Gesture");
						break;
				case "swipe":
						console.log("Swipe Gesture");

						//Classify swipe as either horizontal or vertical
						var isHorizontal = Math.abs(gesture.direction[0]) > Math.abs(gesture.direction[1]);
						//Classify as right-left or up-down
						if (isHorizontal) {
								if (gesture.direction[0] > 0) {
										swipeDirection = "right";
								} else {
										swipeDirection = "left";
								}
						} else { //vertical
								if (gesture.direction[1] > 0) {
										swipeDirection = "up";
										actionOutput.innerHTML = "[" + new Date().getTime() + "] Coffre";
								} else {
										swipeDirection = "down";
								}
						}
						console.log(swipeDirection);

						break;
		}*/
});