using Xunit;
using FirstExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;

namespace FirstExercise.Tests
{
    public class Tests
    {
        [Theory]
        [InlineData(5,10)]
        [InlineData(2,7)]
        [InlineData(0,4)]
        [InlineData(-2,4)]
      
        public void SwapValuesTest(int a,int b)
        {
            int tempA = a;
            int tempB = b;
            a = a + b;
            b = a - b;
            a = a - b;

            var tuple = new Tuple<int, int>(a, b);
            //tuple.Item1.S
            tuple.Item1.Should().Be(tempB);
            tuple.Item2.Should().Be(tempA);
        }
    }
}