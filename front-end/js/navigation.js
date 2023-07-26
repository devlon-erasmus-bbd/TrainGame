function redirectButton(pageName) {
  switch (pageName) {
    case "home":
      window.location.href = "home.html";
      break;
    case "game":
      window.location.href = "game.html";
      break;
    case "score":
      window.location.href = "score.html";
      break;
    default:
      break;
  }
}
