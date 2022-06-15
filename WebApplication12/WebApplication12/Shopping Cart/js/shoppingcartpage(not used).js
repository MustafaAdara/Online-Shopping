let cartcount=localStorage.getItem("cartNumbers");
cartcount = parseInt(cartcount);
if(cartcount){
document.querySelector('.fa-shopping-cart span').textContent = cartcount;

}
else{
    document.querySelector('.fa-shopping-cart span').textContent = 0;
}

/* added cart items count to cart page (above)*/

function displayCart(){
let cartItems = localStorage.getItem("productsInCart");
cartItems=JSON.parse(cartItems);
let productsContainer=document.querySelector(".products");
if(cartItems && productsContainer){
    productsContainer.innerHTML = '';
    Object.values(cartItems).map(item =>{
       productsContainer.innerHTML += `
<div class="product">
<ion-icon name="close-circle-outline"></ion-icon>
<img src="./js/images/${item.name}.jpg">
<span>${item.name}</span>
</div>
<div class="price">
${item.price}
</div>
` 
    });
}
}

displayCart();