<style scoped>

.addmargin {
    margin-top: 10px;
    margin-bottom: 10px;
}

.vue-logo-back {
    background-color: black;
}

</style>

<template>

<div class="home">
    <div class="vue-logo-back">
        <img src="../assets/logo.png" width="100px" height="100px">
    </div>
    <div class="col-md-6 centeralign">
        <p>This Page Displays a list of customers</p>
        <p>Clicking on a Card Displays the name below. This is to demonstrate passing data from parent to child component</p>
        <p>"Click for more details" Redirects to a new page which displays the customer information</p>
        <div class="card centeralign addmargin" style="width: 18rem;" v-for="customer in customerlist" :key="customer.id">
            <div class="card-body" v-on:click="setSelectedCustomer(customer.name)">
                <h5 class="card-title">{{customer.name}}</h5>
                <p class="card-text">{{customer.email}}</p>
                <p class="card-text">{{customer.phone}}</p>
                <a class="btn btn-primary" v-on:click="goToDetailsPage(customer.id)"><span style="color:white">Click for more details</span></a>
            </div>
        </div>
    </div>
    <div>
        <h3>Products</h3>
        <div class="card centeralign addmargin" style="width: 18rem;" v-for="product in productList" :key="product.id">
            <div class="card-body" v-on:click="setSelectedCustomer(product.title)">
                <h5 class="card-title">{{product.title}}</h5>
                <h5 class="card-title">this is emad</h5>
                <p class="card-text">{{product.content}}</p>
                <p class="card-text">{{product.createdAt}}</p>
            </div>
        </div>
    </div>

    <Display v-if="selectedCustomer!=''" :selectedCustomer="selectedCustomer" />
</div>

</template>

<script>

// @ is an alias to /src
import Display from '@/components/Display.vue'
import axios from 'axios'
import apiClient from '@/api'
export default {
    name: 'customers',
    mounted() {
    // Fetch customer list
    axios({
        method: "GET",
        url: "assets/samplejson/customerlist.json"
    }).then(response => {
        this.customerlist = response.data;
    }, error => {
        // eslint-disable-next-line
        console.error(error);
    });

    // Fetch product list
    apiClient({
        method: "GET",
        url: "/Products"
    }).then(response => {
        this.productList = response.data;
    }, error => {
        // eslint-disable-next-line
        console.error(error);
    });
    },
    data() {
        return {
            customerlist: [],
            selectedCustomer: "",
            productList: []
        }
    },
    components: {
        Display
    },
    methods: {
        setSelectedCustomer: function(name) {
            this.selectedCustomer = name;
        },
        goToDetailsPage: function(id) {
            this.$router.push("/customerdetails/"+id);
        }
    }
}

</script>
