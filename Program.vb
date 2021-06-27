Imports System
Imports EPBot64
Module Program
	Private Structure TYPE_HAND
		Dim suit() As String
	End Structure
	Sub Main(args As String())
		Dim dealer, k, j, new_bid, position, vulnerability, suit, level, potential_bid, partner_position As Integer
		Dim meaning As String

		Dim info() As Integer
		Dim Player() As Object
		Const C_PASS As Integer = 0
		Const C_DOUBLE As Integer = 1
		Const C_REDOUBLE As Integer = 2
		Const C_CLUBS As Integer = 0
		Const C_DIAMONDS As Integer = 1
		Const C_HEARTS As Integer = 2
		Const C_SPADES As Integer = 3
		Const C_NT As Integer = 4
		Const C_NS As Integer = 0
		Const C_WE As Integer = 1
		Const C_MP As Integer = 0
		Const C_IMP As Integer = 1
		Const C_INTERPRETED As Integer = 13

		Dim hand() As TYPE_HAND
		Dim SD_tricks() As Integer
		Dim percentages() As Integer
		'ReDim percentages(5)

		ReDim Player(3)

		For k = 0 To 3
			Player(k) = New EPBot
		Next k

		ReDim hand(3)

		For k = 0 To 3
			ReDim hand(k).suit(3)
		Next

		position = 0
		partner_position = 2
		dealer = 0
		vulnerability = 0
		'First 0 means NS first room, WE second room
		'Second 0 means
		'0 - 21GF
		'1 - SAYC
		'2 - WJ
		Player(position).system_type(0) = 0
		Player(position).system_type(1) = 0
		Player(position).scoring = 0

		hand(position).suit(C_SPADES) = "A42"
		hand(position).suit(C_HEARTS) = "A82"
		hand(position).suit(C_DIAMONDS) = "KQ964"
		hand(position).suit(C_CLUBS) = "92"
		hand(partner_position).suit(C_SPADES) = "QJ5"
		hand(partner_position).suit(C_HEARTS) = "93"
		hand(partner_position).suit(C_DIAMONDS) = "JT"
		hand(partner_position).suit(C_CLUBS) = "JT7653"

		Player(position).new_hand(position, hand(position).suit, dealer, vulnerability)
		'Player(position).set_bid(0, 0)
		'Player(position).set_bid(1, 7)
		'Player(position).set_bid(2, 11)
		'Player(position).set_bid(3, 13)
		'Player(position).set_bid(0, 0)
		'Player(position).set_bid(1, 15)
		'Player(position).set_bid(2, 16)
		'Player(position).set_bid(3, 30)
		'Player(position).set_bid(0, 0)
		'Player(position).set_bid(1, 0)
		'Player(position).set_bid(2, 1)
		'new_bid = Player(position).get_bid
		'Console.WriteLine(new_bid)
		'level = new_bid \ 5

		'strain = new_bid Mod 5

		'---interpret the potential bid (C_INTERPRETED = 13) - the new bid is not set yet

		'Player(position).interpret_bid(new_bid)

		'meaning = Player(position).info_meaning(C_INTERPRETED)

		'info = Player(position).info_feature(C_INTERPRETED)

		'info = Player(position).info_honors(C_INTERPRETED)
		'info = Player(position).info_max_length(C_INTERPRETED)
		'info = Player(position).info_min_length(C_INTERPRETED)
		'info = Player(position).info_probable_length(C_INTERPRETED)
		'info = Player(position).info_suit_power(C_INTERPRETED)

		'Player(position).new_hand(position, hand(position).suit, 0, 0)
		SD_tricks = Player(position).get_SD_tricks(hand(partner_position).suit, percentages)
		'SD_tricks = Player(position).get_SD_tricks(position, hand(partner_position).suit)
		Player = Nothing
	End Sub

	Private Function AsString(v As Object) As String
		Dim value
		value = ""
		For I = 255 To 0 Step 1
			value = value + " " + CStr(v(I))
		Next
		'For Each e As String In v
		'	value = value + " " + e
		'		Next
		'Console.WriteLine(value)
		Return value
	End Function
End Module
