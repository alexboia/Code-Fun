<?php
class RomanNumberStringReader {
	private $_string;

	private $_currentIndex;

	private $_lastIndex;

	private $_digitMap = array(
		'I' => 1,
		'V' => 5,
		'X' => 10,
		'L' => 50,
		'C' => 100,
		'D' => 500,
		'M' => 1000
	);

	public function __construct($string) {
		if (empty($string)) {
			throw new InvalidArgumentException();
		}
		$this->_string = $string;
		$this->_currentIndex = 0;
		$this->_lastIndex = strlen($string) - 1;
	}

	private function _getDigitAtIndex($index) {
		$rawDigit = $this->_string[$index];
		if (isset($this->_digitMap[$rawDigit])) {
			return $this->_digitMap[$rawDigit];
		} else {
			return false;
		}
	}

	public function getCurrentDigit() {
		return $this->_getDigitAtIndex($this->_currentIndex);
	}

	public function getNextDigit() {
		if ($this->canMoveNext()) {
			$this->moveNext();
			return $this->getCurrentDigit();
		} else {
			return false;
		}
	}

	public function peekNextDigit() {
		if ($this->canMoveNext()) {
			return $this->_getDigitAtIndex($this->_currentIndex + 1);
		} else {
			return false;
		}
	}

	public function moveNext() {
		if ($this->canMoveNext()) {
			$this->_currentIndex ++;
			return true;
		} else {
			return false;
		}
	}

	public function canMoveNext() {
		return $this->_currentIndex < $this->_lastIndex;
	}

	public function resetReader() {
		$this->_currentIndex = 0;
	}

	public function getString() {
		return $this->_string;
	}
}

class RomanNumberParser {
	public static function decodeNumber($string) {
		$value = 0;
		$reader = new RomanNumberStringReader(strtoupper($string));
		$currentDigit = null;
		$nextDigit = null;

		do {
			$nextDigit = $reader->peekNextDigit();
			$currentDigit = $reader->getCurrentDigit();			

			if ($nextDigit && $currentDigit < $nextDigit) {
				$value += ($nextDigit - $currentDigit);
				$reader->moveNext();
			} else {
				$value += $currentDigit;
			}
		} while ($reader->moveNext());

		return $value;
	}

	public static function encodeNumber($number) {
		$encodedNumber = '';
		$currentNumber = $number;

		$count = floor($currentNumber / 1000);
		$encodedNumber .= self::encodePart($count, 'M', null, null);
		$currentNumber = $currentNumber - $count * 1000;

		$count = floor($currentNumber / 100);
		$encodedNumber .= self::encodePart($count, 'C', 'D', 'M');
		$currentNumber = $currentNumber - $count * 100;
		
		$count = floor($currentNumber / 10);
		$encodedNumber .= self::encodePart($count, 'X', 'L', 'C');
		$currentNumber = $currentNumber - $count * 10;

		return $encodedNumber . self::encodePart($currentNumber, 'I', 'V', 'X');
	}

	private static function encodePart($count, $baseSymbol, $middleSymbol, $nextOrder) {
		if (empty($middleSymbol) && empty($nextOrder)) {
			return str_repeat($baseSymbol, $count);
		}
		switch (true) {
			case $count < 4:
				return str_repeat($baseSymbol, $count);
			case $count == 4:
				return $baseSymbol . $middleSymbol;
			case $count == 5:
				return $middleSymbol;
			case $count > 5 && $count < 9:
				return $middleSymbol . str_repeat($baseSymbol, $count - 5);
			case $count == 9;
				return $baseSymbol . $nextOrder;
			default:
				return '';
		}
	}
}

function runDecodingTests() {
	$decodeResults = array(
		'I' => RomanNumberParser::decodeNumber('I'),
		'V' => RomanNumberParser::decodeNumber('V'),
		'X' => RomanNumberParser::decodeNumber('X'),
		'L' => RomanNumberParser::decodeNumber('L'),
		'C' => RomanNumberParser::decodeNumber('C'),
		'D' => RomanNumberParser::decodeNumber('D'),
		'M' => RomanNumberParser::decodeNumber('M'),
		'IV' => RomanNumberParser::decodeNumber('IV'),
		'VI' => RomanNumberParser::decodeNumber('VI'),
		'IX' => RomanNumberParser::decodeNumber('IX'),
		'XI' => RomanNumberParser::decodeNumber('XI'),
		'XL' => RomanNumberParser::decodeNumber('XL'),
		'XC' => RomanNumberParser::decodeNumber('XC'),
		'CD' => RomanNumberParser::decodeNumber('CD'),
		'CM' => RomanNumberParser::decodeNumber('CM'),
		'MMXV' => RomanNumberParser::decodeNumber('MMXV'),
		'MCMLXXXVI' => RomanNumberParser::decodeNumber('MCMLXXXVI'),
		'XXX' => RomanNumberParser::decodeNumber('XXX'),
		'III' => RomanNumberParser::decodeNumber('III'),
		'CCC' => RomanNumberParser::decodeNumber('CCC'),
		'LLL' => RomanNumberParser::decodeNumber('LLL'),
		'DDD' => RomanNumberParser::decodeNumber('DDD'),
		'MMM' => RomanNumberParser::decodeNumber('MMM'),
		'VVV' => RomanNumberParser::decodeNumber('VVV'),
		'CDXCIV' => RomanNumberParser::decodeNumber('CDXCIV')
	);

	foreach ($decodeResults as $number => $decoded) {
		echo sprintf("%s = %d", $number, $decoded) . PHP_EOL;
	}
}

function runEncodingTests() {
	$encodedResults = array(
		1 => RomanNumberParser::encodeNumber(1),
		5 => RomanNumberParser::encodeNumber(5),
		10 => RomanNumberParser::encodeNumber(10),
		50 => RomanNumberParser::encodeNumber(50),
		100 => RomanNumberParser::encodeNumber(100),
		500 => RomanNumberParser::encodeNumber(500),
		1000 => RomanNumberParser::encodeNumber(1000),
		1986 => RomanNumberParser::encodeNumber(1986),
		4 => RomanNumberParser::encodeNumber(4),
		9 => RomanNumberParser::encodeNumber(9),
		40 => RomanNumberParser::encodeNumber(40),
		90 => RomanNumberParser::encodeNumber(90),
		400 => RomanNumberParser::encodeNumber(400),
		900 => RomanNumberParser::encodeNumber(900),
		1949 => RomanNumberParser::encodeNumber(1949)
	);
	
	foreach ($encodedResults as $number => $encoded) {
		echo sprintf("%d = %s", $number, $encoded) . PHP_EOL;
	}
}

runEncodingTests();