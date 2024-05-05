import matplotlib.pyplot as plt
import numpy as np
import math


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
    x_sum = 0
    y_sum = 0
    xy_sum = 0

    for numbers_index in range(0, len(numbers)):
        x_sum += numbers_index
        y_sum += numbers[numbers_index]
        xy_sum += numbers_index * numbers[numbers_index]

    mean_x = x_sum / n
    mean_y = y_sum / n

    return -1


if __name__ == '__main__':
    input_numbers = get_numbers_from_user()

    if len(input_numbers) > 0:
        print(f"average of numbers: {get_avg(input_numbers)}")
        print(f"amount of positive numbers: {get_positive_amount(input_numbers)}")
        print(f"numbers sorted: {get_sorted_numbers(input_numbers)}")
        show_graph(input_numbers)
        print(f"pearson correlation: {calc_pearson_correlation(input_numbers)}")
    else:
        print("no numbers entered")
