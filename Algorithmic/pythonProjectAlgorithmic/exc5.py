from math import pi


def reverse_n_pi_digits(n: int) -> str:
    divider = "01".zfill(n + 1)
    divider = f"{divider[:1]}.{divider[2:]}"
    return f"{(str(pi // float(divider)))[n - 1::-1]}"
