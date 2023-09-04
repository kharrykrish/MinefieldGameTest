using MinefieldGame.CoreGame;
using Xunit;

namespace MinefieldGame.Tests
{
    public class BoardTests
    {
       
            [Fact]
            public void ItShouldGenerateChessesTilesCorrectly()
            {
                var tiles = new Board(new Display()).GenerateTiles(8, 8);

                Assert.Equal("A1", tiles[0, 0].GetId());
                Assert.Equal("H8", tiles[7, 7].GetId());
                Assert.Equal("D5", tiles[3, 4].GetId());
                Assert.Equal(8, tiles.GetLength(0));
                Assert.Equal(8, tiles.GetLength(1));
            }


            [Fact]
            public void ItShouldGenerateEndTileForB()
            {
                var boardHeight = 8;
                var tile = new Board(new Display()).GenerateFinishTile(1, boardHeight);

                Assert.Equal(typeof(EndTitle), tile.GetType());
                Assert.Equal("B8", tile.GetId());
            }

            [Fact]
            public void ItShouldGenerateEndTileForD()
            {
                var boardHeight = 6;
                var tile = new Board(new Display()).GenerateFinishTile(3, boardHeight);

                Assert.Equal(typeof(EndTitle), tile.GetType());
                Assert.Equal("D6", tile.GetId());
            }

            [Fact]
            public void ItShouldGenerateEndTileForE()
            {
                var boardHeight = 3;
                var tile = new Board(new Display()).GenerateFinishTile(4, boardHeight);

                Assert.Equal(typeof(EndTitle), tile.GetType());
                Assert.Equal("E3", tile.GetId());
            }


    }
    }