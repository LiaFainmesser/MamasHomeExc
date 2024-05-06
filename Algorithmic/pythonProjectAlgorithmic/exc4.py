import matplotlib.pyplot as plt
import numpy as np
from math import sqrt


def get_numbers_from_user() -> list[float]:
    numbers = []
    user_input = float(input("enter number , to exit enter -1: "))
    while user_input != -1:
        numbers.append(user_input)
        user_input = float(input("enter number , to exit enter -1: "))
    return numbers


def get_avg(numbers: list[float]) -> float:
    avg = 0
    for number in numbers:
        avg += number
    return avg / len(numbers)


def get_positive_amount(numbers: list[float]):
    positive_amount = 0
    for number in numbers:
        if number > 0:
            positive_amount += 1
    return positive_amount


def get_sorted_numbers(numbers: list[float]) -> list:
    numbers.sort()
    return numbers


def show_graph(numbers: list[float]):
    ypoints = np.array(numbers)

    plt.plot(ypoints, marker='o')
    plt.show()


def calc_pearson_correlation(numbers: list[float]) -> float:
    n = len(numbers)
    x_avg = 0
    for x in range(1, n + 1):
        x_avg += x
    x_avg = x_avg / n
    y_avg = get_avg(numbers)

    deviation_multiply_sum = 0

    x_deviation_squared_sum = 0
    y_deviation_squared_sum = 0

    for numbers_index in range(1, len(numbers) + 1):
        x = numbers_index
        y = numbers[numbers_index - 1]

        deviation_multiply_sum += (x - x_avg) * (y - y_avg)

        x_deviation_squared_sum += (x - x_avg) ** 2
        y_deviation_squared_sum += (y - y_avg) ** 2

    pearson_correlation = deviation_multiply_sum / sqrt(x_deviation_squared_sum * y_deviation_squared_sum)
    return pearson_correlation


if __name__ == '__main__':
    input_numbers = get_numbers_from_user()

    if len(input_numbers) > 0:
        print(f"average of numbers: {get_avg(input_numbers)}")
        print(f"amount of positive numbers: {get_positive_amount(input_numbers)}")
        show_graph(input_numbers)
        print(f"pearson correlation: {calc_pearson_correlation(input_numbers)}")
        print(f"numbers sorted: {get_sorted_numbers(input_numbers)}")
    else:
        print("no numbers entered")
