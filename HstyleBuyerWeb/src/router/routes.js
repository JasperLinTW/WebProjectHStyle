const routes = [
    { path: '/',name:'Home', component: ()=> import('../views/Home.vue') },
    { path: '/product',name:'Product', component:()=> import('../views/product.vue') },
    { path: '/product/:id',name:'SingleProduct', component:()=> import('../views/SingleProduct.vue') },
    { path: '/recommend',name:'Recommend', component:()=> import('../views/Recommend.vue') },
    { path: '/blog',name:'Blog', component:()=> import('../views/Blog.vue') }
  ]
export default routes