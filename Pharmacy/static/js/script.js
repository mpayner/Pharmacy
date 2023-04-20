countOrderSum();
let form = document.getElementsByClassName('cart_form');
for(let i=0;i<form.length;i++){
    let quantity = form.item(i).getElementsByTagName('input').item(1);
    let quantity_value = quantity.value;
    quantity.addEventListener('change', function () {
        let old_quantity = quantity_value;
        if (this.value !== old_quantity) {
            setTimeout(form[i].submit(), 1000);
        }
        
    })
}

function countOrderSum() {
    let sum = 0.0;
    let prices = document.getElementsByClassName('summary_price');
    for (let i = 0; i < prices.length; i++) {
        sum += parseFloat(prices[i].textContent.replace(",", '.'));

    };
    document.getElementById('order-price').textContent = sum.toFixed(2);
}