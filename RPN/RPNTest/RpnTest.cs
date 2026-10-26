namespace RPNTest;

[TestFixture]
public class RpnTest {
    private Rpn _sut;
    [SetUp]
    public void Setup() {
        _sut = new Rpn();
    }
    [Test]
    public void CheckIfTestWorks() {
        Assert.Pass();
    }

    [Test]
    public void CheckIfCanCreateSut() {
        Assert.That(_sut, Is.Not.Null);
    }

    [Test]
    public void SingleDigitOneInputOneReturn() {
        var result = _sut.EvalRpn("1");

        Assert.That(result, Is.EqualTo(1));

    }
    [Test]
    public void SingleDigitOtherThenOneInputNumberReturn() {
        var result = _sut.EvalRpn("2");

        Assert.That(result, Is.EqualTo(2));

    }
    [Test]
    public void TwoDigitsNumberInputNumberReturn() {
        var result = _sut.EvalRpn("12");

        Assert.That(result, Is.EqualTo(12));

    }
    [Test]
    public void TwoNumbersGivenWithoutOperator_ThrowsExcepton() {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("1 2"));

    }
    [Test]
    public void OperatorPlus_AddingTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("1 2 +");

        Assert.That(result, Is.EqualTo(3));
    }
    [Test]
    public void OperatorTimes_AddingTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("2 2 *");

        Assert.That(result, Is.EqualTo(4));
    }
    [Test]
    public void OperatorMinus_SubstractingTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("1 2 -");

        Assert.That(result, Is.EqualTo(-1));
    }
    [Test]
    public void ComplexExpression() {
        var result = _sut.EvalRpn("15 7 1 1 + - / 3 * 2 1 1 + + -");

        Assert.That(result, Is.EqualTo(5));
    }


    // tresc polecenia:

    //systemy liczbowe:
    [Test]
    public void DecimalWithPrefix_D10_returns10() {
        var result = _sut.EvalRpn("D10");

        Assert.That(result, Is.EqualTo(10));
    }
    [Test]
    public void Binary_B101_returns5() {
        var result = _sut.EvalRpn("B101");

        Assert.That(result, Is.EqualTo(5));
    }
    [Test]
    public void Binary_B0_returns0() {
        var result = _sut.EvalRpn("B0");

        Assert.That(result, Is.EqualTo(0));
    }
    [Test]
    public void Hex_HashAB_Returns171() {
        var result = _sut.EvalRpn("#AB");

        Assert.That(result, Is.EqualTo(171));
    }
    [Test]
    public void Hex_HashFF_Returns255() {
        var result = _sut.EvalRpn("#FF");

        Assert.That(result, Is.EqualTo(255));
    }
    [Test]
    public void MixedBases_HashBA_Plus_D13_Returns199() {
        var result = _sut.EvalRpn("#BA D13 +");

        Assert.That(result, Is.EqualTo(199));
    }
    [Test]
    public void MixedBases_BinaryAndDecimal_Add() {
        var result = _sut.EvalRpn("B101 D10 +");

        Assert.That(result, Is.EqualTo(15));
    }
    [Test]
    public void MixedBases_AllThreeSystems_Add() {
        var result = _sut.EvalRpn("B101 #AB D10 + +");

        Assert.That(result, Is.EqualTo(186));
    }

    // operacje dwuargumentowe:

    [Test]
    public void Divide_DividingTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("10 2 /");

        Assert.That(result, Is.EqualTo(5));
    }
    [Test]
    public void OperatorDivide_IntegerDivision() {
        var result = _sut.EvalRpn("10 3 /");

        Assert.That(result, Is.EqualTo(3));
    }
    [Test]
    public void OperatorPlus_WithDecimalPrefix() {
        var result = _sut.EvalRpn("D10 D5 +");

        Assert.That(result, Is.EqualTo(15));
    }
    [Test]
    public void OperatorMinus() {
        var result = _sut.EvalRpn("D15 D10 -");

        Assert.That(result, Is.EqualTo(5));
    }
    [Test]
    public void OperatorTimes_WithBinaryPrefix() {
        var result = _sut.EvalRpn("B101 B10 *");

        Assert.That(result, Is.EqualTo(10));
    }
    [Test]
    public void OperatorTimes_WithHexPrefix() {
        var result = _sut.EvalRpn("#FF #10 *");

        Assert.That(result, Is.EqualTo(4080));
    }
    [Test]
    public void OperatorDivide_WithBinaryPrefix() {
        var result = _sut.EvalRpn("B101 B10 /");

        Assert.That(result, Is.EqualTo(2));
    }
    [Test]
    public void ComplexExpression_WithMixedBases() {
        var result = _sut.EvalRpn("B101 #AB D10 + + 2 /");

        Assert.That(result, Is.EqualTo(93));
    }

    // operacje jednoargumentowe:

    [Test]
    public void UnaryAbs_PositiveNumber_ReturnsPositiveNumber() {
        var result = _sut.EvalRpn("10 ABS");

        Assert.That(result, Is.EqualTo(10));
    }
    [Test]
    public void UnaryAbs_NegativeNumber_ReturnsPositiveNumber() {
        var result = _sut.EvalRpn("-10 ABS");

        Assert.That(result, Is.EqualTo(10));
    }
    [Test]
    public void UnaryFactorial_B101_Returns120() {
        var result = _sut.EvalRpn("B101 !");

        Assert.That(result, Is.EqualTo(120));
    }
    [Test]
    public void UnaryFactorial_D10_Returns3628800() {
        var result = _sut.EvalRpn("D10 !");

        Assert.That(result, Is.EqualTo(3628800));
    }
    [Test]
    public void UnaryFactorial_Zero_Returns1() {
        var result = _sut.EvalRpn("0 !");

        Assert.That(result, Is.EqualTo(1));
    }
    [Test]
    public void UnaryFactorial_One_Returns1() {
        var result = _sut.EvalRpn("1 !");

        Assert.That(result, Is.EqualTo(1));
    }
    [Test]
    public void UnaryThenBinary_Combined() {
        var result = _sut.EvalRpn("B101 ! D2 /");

        Assert.That(result, Is.EqualTo(60));
    }

    // Błędy:

    [Test]
    public void TooManyValuesLeftOnStack_ThreeNumbers_Throws() {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("1 2 3"));
    }

    [Test]
    public void BinaryOperator_TooFewArguments_Throws() {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("1 +"));
    }

    [Test]
    public void BinaryOperator_EmptyStack_Throws() {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("+"));
    }

    [Test]
    public void BinaryOperator_OnlyOneNumberThenMultiply_Throws() {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("5 *"));
    }

    [Test]
    public void BinaryOperator_OnlyOneNumberThenDivide_Throws() {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("5 /"));
    }

    [Test]
    public void UnaryAbs_EmptyStack_Throws() {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("ABS"));
    }

    [Test]
    public void UnaryFactorial_EmptyStack_Throws() {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("!"));
    }

    [Test]
    public void UnaryAbs_TooFewArguments_Throws() {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("1 2 ABS"));
    }

    // Błędy dzielenie przez zero:

    [Test]
    public void DivideByZero_ThrowsDivideByZeroException() {
        Assert.Throws<DivideByZeroException>(() => _sut.EvalRpn("5 0 /"));
    }

    [Test]
    public void DivideByZero_WithPrefixes_ThrowsDivideByZeroException() {
        Assert.Throws<DivideByZeroException>(() => _sut.EvalRpn("D10 B0 /"));
    }

    // Błędy błędny format liczby:

    [Test]
    public void InvalidBinary_DigitTwo_Throws() {
        Assert.Throws<ArgumentException>(() => _sut.EvalRpn("B102"));
    }

    [Test]
    public void InvalidBinary_Letter_Throws() {
        Assert.Throws<ArgumentException>(() => _sut.EvalRpn("B1A"));
    }

    [Test]
    public void InvalidHex_XY_Throws() {
        Assert.Throws<ArgumentException>(() => _sut.EvalRpn("#XY"));
    }

    [Test]
    public void InvalidHex_LetterG_Throws() {
        Assert.Throws<ArgumentException>(() => _sut.EvalRpn("#G"));
    }

    [Test]
    public void EmptyDecimalPrefix_Throws() {
        Assert.Throws<ArgumentException>(() => _sut.EvalRpn("D"));
    }

    [Test]
    public void EmptyBinaryPrefix_Throws() {
        Assert.Throws<ArgumentException>(() => _sut.EvalRpn("B"));
    }

    [Test]
    public void EmptyHexPrefix_Throws() {
        Assert.Throws<ArgumentException>(() => _sut.EvalRpn("#"));
    }

    // Błędy nierozpoznany symbol / operator:

    [Test]
    public void UnknownOperator_QuestionMark_Throws() {
        Assert.Throws<ArgumentException>(() => _sut.EvalRpn("1 2 ?"));
    }

    [Test]
    public void UnknownOperator_Word_Throws() {
        Assert.Throws<ArgumentException>(() => _sut.EvalRpn("1 2 ADD"));
    }

    [Test]
    public void UnknownToken_SingleGarbage_Throws() {
        Assert.Throws<ArgumentException>(() => _sut.EvalRpn("@@@"));
    }
}