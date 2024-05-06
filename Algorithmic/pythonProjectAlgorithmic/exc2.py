def pythagorean_triplet_by_sum(sum: int):
    for t in range(1, sum + 1):
        for s in range(1, sum + 1):
            if t != s and ((t % 2 == 0 and s % 2 != 0) or (t % 2 != 0 and s % 2 == 0)) and s > t:
                a = s ** 2 - t ** 2
                b = 2 * s * t
                c = s ** 2 + t ** 2

                if a + b + c == sum:
                    print(f"{a} < {b} < {c}")
