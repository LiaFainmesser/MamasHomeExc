import math


def num_len(input_number: int) -> int:
    return int(math.log10(input_number)) + 1
