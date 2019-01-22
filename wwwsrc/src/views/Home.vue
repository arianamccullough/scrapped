<template>
  <div class="home">

    <h1>Welcome Home</h1>
    <form @submit.prevent="addKeep">
      <input type="text" v-model="newKeep.name" placeholder="Name..." name="Name">
      <input type="text" v-model="newKeep.img" placeholder="Image..." name="Img">
      <input type="text" v-model="newKeep.description" placeholder="Description..." name="Description">
      <!-- <input type="number" v-model="newKeep.zip" placeholder="Zip..." name="Location"> -->
      <label for="isPrivate">
        Keep Private?
        <input type="checkbox" v-model="newKeep.isPrivate" name="isPrivate">
      </label>


      <button type="submit">Add Keep</button>
    </form>
    <div class="row">
      <div v-for="keep in keeps">
        <div v-show="keep.isPrivate == false">
          <keep :keep="keep"></keep>
        </div>
      </div>
    </div>


  </div>
</template>

<script>
  import keep from '@/components/Keep.vue'
  export default {
    name: "home",
    data() {
      return {
        newKeep: {
          name: '',
          description: '',
          img: '',
          isPrivate: true || false,

        }
      }
    },
    computed: {
      keeps() {
        return this.$store.state.keeps || []
      }

    },
    components: {
      keep
    },

    methods: {
      addKeep() {
        this.$store.dispatch("addKeep", this.newKeep);
        this.newKeep = { name: "", img: "", description: "", location: "", isPrivate: "" };
      },

    },
    created() {
      this.$store.dispatch('getAllKeeps', this.newKeep)
    },

  }
</script>