import requests

class DataFetcher:
    def __init__(self, url):
        self.url = url
    
    def fetch_data(self):
        response = requests.get(self.url)
        if response.status_code == 200:
            return response.json()
        else:
            return None
