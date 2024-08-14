def process_data(data_list):
    result = []
    for item in data_list:
        if isinstance(item, dict):
            temp = []
            for key in item:
                temp.append(f"{key}:{item[key]}")
            result.append(",".join(temp))
        elif isinstance(item, list):
            result.append(";".join([str(i) for i in item]))
        else:
            result.append(str(item))
    return result
