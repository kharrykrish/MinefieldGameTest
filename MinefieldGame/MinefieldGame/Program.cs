// See https://aka.ms/new-console-template for more information
using MinefieldGame.CoreGame;

Console.WriteLine("Hello, World!");

var desingDisplay = new Display();
var board = new Board(desingDisplay);
new GameEngine().Start(board, new Player(board, desingDisplay));
