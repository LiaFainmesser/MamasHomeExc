def is_sorted_polyndrom(user_input: str) -> bool:
    if is_polyndrom(user_input) and user_input.isalpha():

        start_of_polyndrom = user_input[:len(user_input) // 2 + 1]
        print(start_of_polyndrom)

        if is_str_sorted(start_of_polyndrom):
            return True
    return False


def is_str_sorted(user_input: str) -> bool:
    user_input = user_input.lower()
    for letter_index in range(0, len(user_input) - 1):
        if ord(user_input[letter_index]) > ord(user_input[letter_index + 1]):
            return False
    return True


def is_polyndrom(user_input: str) -> bool:
    start = user_input[:len(user_input) // 2]
    if len(user_input) % 2 == 0:
        end = user_input[len(user_input) - 1:(len(user_input) // 2) - 1: -1]
    else:
        end = user_input[len(user_input) - 1:(len(user_input) // 2): -1]

    return end == start


