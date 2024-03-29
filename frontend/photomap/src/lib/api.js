export const fetchPoints = async (category = null) => {
    try {
      let url = 'http://localhost:5247/v1/Point';
      if (category) {
        url = `http://localhost:5247/v1/Point/category/${category}`;
      }
      const response = await fetch(url, {
        headers: {
          'Authorization': 'Bearer YOUR_ACCESS_TOKEN_HERE',
          'Accept': 'application/json'
        }
      });
      const data = await response.json();
      return data;
    } catch (error) {
      console.error('Error fetching points:', error);
      return [];
    }
  };
  
  export const fetchCategories = async () => {
    try {
      const response = await fetch('http://localhost:5247/v1/PointCategory');
      const data = await response.json();
      return [{ id: 'all', title: 'Все' }, ...data];
    } catch (error) {
      console.error('Error fetching categories:', error);
      return [];
    }
  };
  
  export const fetchPointsBySearch = async (query) => {
    try {
        const url = `http://localhost:5247/v1/Point/search?query=${encodeURIComponent(query)}`;
        const response = await fetch(url, {
            headers: {
                'Authorization': 'Bearer YOUR_ACCESS_TOKEN_HERE',
                'Accept': 'application/json'
            }
        });
        const data = await response.json();
        return data;
    } catch (error) {
        console.error('Error fetching points:', error);
        return [];
    }
};
