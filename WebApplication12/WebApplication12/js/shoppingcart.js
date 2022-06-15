let carts = document.querySelectorAll('.cart-btn');
let products = [{
        name: 'Badia Allspice', tag :'herb', price: 105.30 , inCart:0} ,
        {
            name:'Basil Leaves', tag:'herb',price :95 , inCart:0},{
            name: 'Keya Rosemary' , tag:'herb',price :95 , inCart:0},
               
                {
                    name:'Bergamot Essential Oil', tag:'herb',price:33.6, inCart : 0},{
    name : 'Dragon Fruit', tag:'fruit', price:74.70 , inCart : 0 },
                
              {name : 'Oranges', tag:'fruit',price:7,inCart:0 },
                {name :'Strawberries',tag:'fruit',price:8.2,inCart: 0},
                {name:'Tanjerine', tag:'fruit',price:10.08 , inCart: 0},
                {name:'Avocado',tag:'fruit',price:85.5,inCart:0}
            
        
               
    ]
               
for(let i =0; i<carts.length;i++)
    {
        carts[i].addEventListener('click',()=> {
          cartNumbers(products[i]);
            totalCost(products[i]);
        })
    }
function cartNumbers(products){
    let productNumbers = localStorage.getItem('cartNumbers');
    productNumbers = parseInt(productNumbers);
    if(productNumbers){
        localStorage.setItem('cartNumbers',productNumbers+1);
        document.querySelector('.fa-shopping-cart span').textContent = productNumbers+1;
    }
    else{
        localStorage.setItem('cartNumbers',1);
        document.querySelector('.fa-shopping-cart span').textContent = 1;
    }
    setItems(products); 
    
    
}
function onLoadCartNumbers(){
    let productNumbers = localStorage.getItem('cartNumbers');
    
    if(productNumbers){
        document.querySelector('.fa-shopping-cart span').textContent = productNumbers;
    }
}
function setItems(products){
    let cartItems = localStorage.getItem('productsInCart');
    cartItems=JSON.parse(cartItems);
    if(cartItems !=null){
        if(cartItems[products.name] == undefined){
           cartItems = {
                ...cartItems,[products.name]:products
            }
        }
      cartItems[products.name].inCart+=1;
    }
    else{
        
    
    products.inCart=1;
    cartItems={
        [products.name]:products
    }}
    localStorage.setItem("productsInCart", JSON.stringify(cartItems));
}
onLoadCartNumbers();
function totalCost(products){
    let cartCost=localStorage.getItem('totalCost');
    
    if(cartCost !=null){
        cartCost=parseInt(cartCost);
    localStorage.setItem("totalCost", cartCost+products.price);
    }else{
        localStorage.setItem("totalCost", products.price);
    }
    
    
}
function displayCart(){
let cartItems = localStorage.getItem("productsInCart");
cartItems=JSON.parse(cartItems);
let productsContainer=document.querySelector(".products");
let cartCost=localStorage.getItem('totalCost');
if(cartItems && productsContainer){
    productsContainer.innerHTML = '';
    Object.values(cartItems).map(item =>{
       productsContainer.innerHTML += `
<div class="product">
<ion-icon name="close-circle-outline"></ion-icon>
<img src="./js/images/${item.name}.jpg">
<span>${item.name}</span>
</div>
<div class="price">Price:EGP${item.price}
</div>
<div class="quantity">
Quantity:${item.inCart}
</div>
<div class="total">
TotalPrice:EGP${item.inCart * item.price}
</div>
<div class="type">
Type:${item.tag}
</div>
`
       ; 
    });
    productsContainer.innerHTML+=`
<div class="basketTotalContainer">
<h4 class="basketTotalTitle">
Basket Total : </h4>
<h4 class="basketTotal">
  EGP ${cartCost} </h4>
`;
}
}

displayCart();