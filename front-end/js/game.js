const questions = [
  {
    question: "Is bread heavier than a train?",
    optionA: "True",
    optionB: "False",
    correctOption: "optionB",
  },
  {
    question: "Is the moon heavier than a train?",
      optionA: "True",
      optionB: "False",
      correctOption: "optionA",
  },
  {
    question: "Is the earth heavier than a train?",
    optionA: "True",
    optionB: "False",
    correctOption: "optionA",
  },
  {
    question: "Is a toaster heavier than a train?",
    optionA: "True",
    optionB: "False",
    correctOption: "optionB",
  },
];

let shuffledQuestions = [];

function handleQuestions() {
  while (shuffledQuestions.length <= 3) {
    const random = questions[Math.floor(Math.random() * questions.length)];
    if (!shuffledQuestions.includes(random)) {
      shuffledQuestions.push(random);
    }
  }
}

let questionNumber = 1;
let playerScore = 0;
let wrongAttempt = 0;
let indexNumber = 0;

function NextQuestion(index) {
  handleQuestions();
  const currentQuestion = shuffledQuestions[index];
  document.getElementById("player-score").innerText = playerScore;
  document.getElementById("display-question").innerText = currentQuestion.question;
  document.getElementById("option-one-label").innerText = currentQuestion.optionA;
  document.getElementById("option-two-label").innerText = currentQuestion.optionB;
}

function checkForAnswer() {
  const currentQuestion = shuffledQuestions[indexNumber];
  const currentQuestionAnswer = currentQuestion.correctOption;
  const options = document.getElementsByName("option");
  let correctOption = null;

  options.forEach((option) => {
    if (option.value === currentQuestionAnswer) {
      correctOption = option.labels[0].id;
    }
  });

  if (
    options[0].checked === false &&
    options[1].checked === false
  ) {
    document.getElementById("option-modal").style.display = "flex";
  }

  options.forEach((option) => {
    if (option.checked === true && option.value === currentQuestionAnswer) {
      document.getElementById(correctOption).style.backgroundColor = "green";
      playerScore++;
      indexNumber++;
      setTimeout(() => {
        questionNumber++;
      }, 1000);
    } else if (option.checked && option.value !== currentQuestionAnswer) {
      const wrongLabelId = option.labels[0].id;
      document.getElementById(wrongLabelId).style.backgroundColor = "red";
      document.getElementById(correctOption).style.backgroundColor = "green";
      setTimeout(() => {
        questionNumber++;
      }, 1000);
      handleEndGame()
    }
  });
}

function handleNextQuestion() {
  checkForAnswer();
  unCheckRadioButtons();
  setTimeout(() => {
    if (indexNumber <= 3) {
      NextQuestion(indexNumber);
    } else {
      handleEndGame();
    }
    resetOptionBackground();
  }, 1000);
}

function resetOptionBackground() {
  const options = document.getElementsByName("option");
  options.forEach((option) => {
    document.getElementById(option.labels[0].id).style.backgroundColor = "";
  });
}

function unCheckRadioButtons() {
  const options = document.getElementsByName("option");
  for (let i = 0; i < options.length; i++) {
    options[i].checked = false;
  }
}

function handleEndGame() {
  document.getElementById("right-answers").innerText = playerScore;
  document.getElementById("score-modal").style.display = "flex";
}

function closeScoreModal() {
  questionNumber = 1;
  playerScore = 0;
  wrongAttempt = 0;
  indexNumber = 0;
  shuffledQuestions = [];
  NextQuestion(indexNumber);
  document.getElementById("score-modal").style.display = "none";
}

function closeOptionModal() {
  document.getElementById("option-modal").style.display = "none";
}
