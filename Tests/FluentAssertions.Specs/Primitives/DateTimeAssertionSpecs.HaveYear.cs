﻿using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeAssertionSpecs
{
    public class HaveYear
    {
        [Fact]
        public void When_asserting_subject_datetime_should_have_year_with_the_same_value_should_succeed()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31);
            int expectation = 2009;

            // Act
            Action act = () => subject.Should().HaveYear(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_datetime_should_have_year_with_a_different_value_should_throw()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31);
            int expectation = 2008;

            // Act
            Action act = () => subject.Should().HaveYear(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected the year part of subject to be 2008, but found 2009.");
        }

        [Fact]
        public void When_asserting_subject_null_datetime_should_have_year_should_throw()
        {
            // Arrange
            DateTime? subject = null;
            int expectation = 2008;

            // Act
            Action act = () => subject.Should().HaveYear(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected the year part of subject to be 2008, but found <null>.");
        }
    }

    public class NotHaveYear
    {
        [Fact]
        public void When_asserting_subject_datetime_should_not_have_year_with_the_same_value_should_throw()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31);
            int expectation = 2009;

            // Act
            Action act = () => subject.Should().NotHaveYear(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the year part of subject to be 2009, but it was.");
        }

        [Fact]
        public void When_asserting_subject_datetime_should_not_have_year_with_a_different_value_should_succeed()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31);
            int expectation = 2008;

            // Act
            Action act = () => subject.Should().NotHaveYear(expectation);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_asserting_subject_null_datetime_should_not_have_year_should_throw()
        {
            // Arrange
            DateTime? subject = null;
            int expectation = 2008;

            // Act
            Action act = () => subject.Should().NotHaveYear(expectation);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Did not expect the year part of subject to be 2008, but found a <null> DateTime.");
        }
    }
}
