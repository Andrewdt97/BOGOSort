﻿using ai;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xunit;
using FluentAssertions;

namespace test
{
    public class Test
    {
        [Fact]
        public void Deserialize_Game_Message()
        {
            const string input = @"{""board"":[[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,1,0,0,0],[0,0,0,1,1,0,0,0],[0,0,0,2,1,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0]],""maxTurnTime"":15000,""player"":2}";
            var obj = JsonConvert.DeserializeObject<GameMessage>(input);

            obj.maxTurnTime.Should().Be(15000);
            obj.player.Should().Be(2);
            obj.board.Length.Should().Be(8);
            obj.board[0].Length.Should().Be(8);
            obj.board[0][0].Should().Be(0);
            obj.board[3][3].Should().NotBe(0);

        }

        [Fact]
        public void FindMoves()
        {
            const string input = @"{""board"":[[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,1,0,0,0],[0,0,0,1,1,0,0,0],[0,0,0,2,1,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0]],""maxTurnTime"":15000,""player"":2}";
            var obj = JsonConvert.DeserializeObject<GameMessage>(input);

            List<int[]> moves = AI.GetPossibleMoves(obj.board, obj.player);

            foreach (int[] move in moves)
            {
                Console.WriteLine("Move: " + move[0] + ", " + move[1]);
            }
        }

    }
}
