function addToBasket(productId, productName, price, imageUrl) {
    let basket = JSON.parse(localStorage.getItem("basket")) || [];

    const existingProduct = basket.find(x => x.productId === productId);

    if (existingProduct) {
        existingProduct.quantity += 1;
    } else {
        basket.push({
            productId: productId,
            productName: productName,
            price: price,
            imageUrl: imageUrl,
            quantity: 1
        });
    }

    localStorage.setItem("basket", JSON.stringify(basket));

    alert(productName + " added to basket.");
}