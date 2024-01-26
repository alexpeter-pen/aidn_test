# aidn_test
A case assignment as part of the recruitment process for the position of Senior Backend Engineer at Aidn

In this simplified example, all input measurements are provided as a type and a value. There are three types of measurements
that must be provided to calculate a score—body temperature (TEMP), heart rate (HR), and respiratory rate (RR). Input
measurements should specify the type as a capitalised enumeration and the value as an integer.
For each measurement, your program should calculate an individual score by evaluating the input value against a defined set
of ranges. All starting values are exclusive; all ending values are inclusive. Values outside of the defined ranges are invalid.
The three individual scores are then summed to produce a final NEWS score.

TEMP Range Score

31..35 3

35..36 1

36..38 0

38..39 1

39..42 2

HR Range Score

25..40 3

40..50 1

50..90 0

90..110 1

110..130 2

130..220 3

RR Range Score

3..8 3

8..11 1

11..20 0

20..24 2

24..60 3

Example
Given the following input values:
{
 measurements: \[
{ type: “TEMP”, value: 37 },
 { type: “HR”, value: 60 },
 { type: “RR”, value: 5 },
 \]
}

The endpoint should return:
{ score: 3 }
